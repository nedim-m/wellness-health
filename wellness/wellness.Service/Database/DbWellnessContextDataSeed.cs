using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wellness.Service.Database
{
    partial class DbWellnessContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Administrator", Description = "Administracija" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Worker-first-shift", Description = "Evidencija prisutnih, rezervacija i tretmana", ShiftTime = "od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Member", Description = "Korisnik" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Name = "Worker-second-shift", Description = "Evidencija prisutnih, rezervacija i tretmana", ShiftTime = "od 16:00 do 23:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 5, Name = "Trainer-first-shift", Description = "Fitnes trener", ShiftTime = "od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 6, Name = "Trainer-second-shift", Description = "Fitnes trener", ShiftTime = "od 16:00 do 23:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 7, Name = "Physiotherapist-first-shift", Description = "Fizijatar", ShiftTime = "od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 8, Name = "Physiotherapist-second-shift", Description = "Fizijatar", ShiftTime = "od 16:00 do 23:00" });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "admin",
                Phone = "061111222",
                Status = true,
                RoleId = 1,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Worker",
                LastName = "Worker",
                Email = "worker@admin.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "worker",
                Phone = "061112333",
                Status = true,
                RoleId = 2,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3ad,
                FirstName = "Member",
                LastName = "Member",
                Email = "member@admin.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "worker",
                Phone = "061110121",
                Status = true,
                RoleId = 3,
            });



        }
        public static byte[] HexToByteArray(string hex)
        {
            hex = hex.Replace("0x", ""); 
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }


    }
}
