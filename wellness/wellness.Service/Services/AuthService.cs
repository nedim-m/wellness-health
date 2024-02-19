using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using wellness.Model.User;
using wellness.Models.User;
using wellness.Service.Database;
using wellness.Service.IServices;

namespace wellness.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly DbWellnessContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;



        public AuthService(DbWellnessContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _mapper=mapper;
        }

        public async Task<AuthResponse> Login(UserLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.UserName);
            if (user == null)
            {
                return new AuthResponse { Message = "User not found." };
            }
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new AuthResponse { Message = "Wrong Password." };
            }

            if(user.RoleId!=3 && user.Status==false)
            {
                return new AuthResponse { Message = "Your account has been disabled",
                    Success = false,
                };
            }


            string token = CreateToken(user);
            var refreshToken = CreateRefreshToken();
            await SetRefreshToken(refreshToken, user);

            return new AuthResponse
            {
                Message=user.RoleId.ToString(),
                Success = true,
                Token = token,
                RefreshToken = refreshToken.Token,
                TokenExpires = refreshToken.Expires
            };
        }

        public async Task<AuthResponse> RefreshToken()
        {
            var refreshToken = _httpContextAccessor?.HttpContext?.Request.Cookies["refreshToken"];
            var user = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user == null)
            {
                return new AuthResponse { Message = "Invalid Refresh Token" };
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return new AuthResponse { Message = "Token expired." };
            }

            string token = CreateToken(user);
            var newRefreshToken = CreateRefreshToken();
            await SetRefreshToken(newRefreshToken, user);

            return new AuthResponse
            {
                Message=user.RoleId.ToString(),
                Success = true,
                Token = token,
                RefreshToken = newRefreshToken.Token,
                TokenExpires = newRefreshToken.Expires
            };
        }

        public async Task<Models.User.User?> RegisterUser(UserRegisterRequest request)
        {

            if (request.Password != request.ConfrimPassword)
            {
                return null;
            }

           
            if (_context.Users.Any(u => u.UserName == request.UserName))
            {
               
                return null;
            }
            if (_context.Users.Any(u => u.Email == request.Email))
            {

                return null;
            }


            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

    
            var user = _mapper.Map<Database.User>(request);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.RoleId = 3;
            user.ShiftId=1;

       
            _context.Users.Add(user);

           
            await _context.SaveChangesAsync();

           
            return _mapper.Map<Models.User.User>(user);
        }


        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private string CreateToken(Database.User user)
        {
            var userRole = _context.Roles.Find(user.RoleId)!.Name;
            

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, (user.FirstName +" "+ user.LastName)),
                new Claim(ClaimTypes.Role,userRole)
            };

#pragma warning disable CS8604 // Possible null reference argument.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
#pragma warning restore CS8604 // Possible null reference argument.

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private static RefreshToken CreateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private async Task SetRefreshToken(RefreshToken refreshToken, Database.User user)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.Expires,
            };
            _httpContextAccessor?.HttpContext?.Response
                .Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);

            user.RefreshToken = refreshToken.Token;
            user.TokenCreated = refreshToken.Created;
            user.TokenExpires = refreshToken.Expires;

            await _context.SaveChangesAsync();
        }
    }
}
