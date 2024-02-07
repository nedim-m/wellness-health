using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Org.BouncyCastle.Pkix;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using wellness.RabbitMQ;
using wellness.Service.Database;
using wellness.Service.IServices;
using wellness.Service.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
#pragma warning disable CS8604 // Possible null reference argument.
        opt.TokenValidationParameters=new TokenValidationParameters
        {
            ValidateIssuerSigningKey=true,
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer=false,
            ValidateAudience=false

        };
#pragma warning restore CS8604 // Possible null reference argument.
    });

builder.Services.AddCors(options => options.AddPolicy(name: "NgOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:7081").AllowAnyMethod().AllowAnyHeader();
    }));


builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<ITreatmentTypeService, TreatmentTypeService>();
builder.Services.AddTransient<ITreatmentService, TreatmentService>();
builder.Services.AddTransient<IMembershipTypeService, MembershipTypeService>();
builder.Services.AddTransient<IRecordService, RecordService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IReservationService, ReservationService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IMembershipService, MembershipService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddTransient<RabbitMQService>();
builder.Services.AddTransient<MailService>();





builder.Services.AddAutoMapper(typeof(AuthService));

builder.Services.AddLogging(builder => builder.AddConsole());


builder.Services.AddDbContext<DbWellnessContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
