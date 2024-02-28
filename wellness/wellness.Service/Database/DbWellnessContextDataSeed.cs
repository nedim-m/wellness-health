using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace wellness.Service.Database
{
    partial class DbWellnessContext
    {

   
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            //Roles
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = "Administrator", Description = "Administracija" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Employee", Description = "Evidencija prisutnih, rezervacija i tretmana" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Member", Description = "Korisnik" });


            //Shifts
            modelBuilder.Entity<Shift>().HasData(new Shift { Id = 1, Name ="Admin/Member", WorkingHours=" " });
            modelBuilder.Entity<Shift>().HasData(new Shift { Id =2, Name ="Prva smjena", WorkingHours="08:00 - 14:00" });
            modelBuilder.Entity<Shift>().HasData(new Shift { Id = 3, Name ="Druga smjena", WorkingHours="14:00 - 20:00" });

            //MemberShipTypes
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 1, Name ="Membership 1", Description="Opis membership 1", Duration=30, Price=60 });
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 2, Name ="Membership 2", Description="Opis membership 2", Duration=60, Price=120 });

            //Categories
            modelBuilder.Entity<Category>().HasData(new Category { Id=1, Name="Category 1", Description="Description of Category 1" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=2, Name="Category 2", Description="Description of Category 2" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=3, Name="Category 3", Description="Description of Category 3" });

            //TreatmentTypes
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=1, Name="TreatmentType 1", Description="Description of TreatmentType 1" });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=2, Name="TreatmentType 2", Description="Description of TreatmentType 2" });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=3, Name="TreatmentType 3", Description="Description of TreatmentType 3" });

            //Treatments
            /*modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 1,
                Name="Tretman lica jedan",
                TreatmentTypeId = 1,
                CategoryId = 1,
                Description = "Description of Treatment 1",
                Duration = 120,
                Price = 120,
                Picture = ConvertImageToByteArray("tretman-lica1.jpg")
            });
            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 2,
                Name="Tretman lica dva",
                TreatmentTypeId = 1,
                CategoryId = 2,
                Description = "Description of Treatment 2",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("tretman-lica2.jpg")
            });
            */






            //Users
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
                ShiftId=1,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                FirstName = "Employee",
                LastName = "Employee",
                Email = "employee@admin.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "employee",
                Phone = "061112333",
                Status = true,
                RoleId = 2,
                ShiftId=2,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "Member",
                LastName = "Member",
                Email = "member@member.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "member",
                Phone = "061110121",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "Korisnik",
                LastName = "Korisnik",
                Email = "korisnik@korisnik.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "korisnik",
                Phone = "061110123",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 5,
                FirstName = "Nedim",
                LastName = "Misic",
                Email = "nedim_misic@hotmail.com",
                PasswordHash = HexToByteArray("79C4E5E29CE28441CFFE5A980F30930A59BC4176DC5F7A546AFBA7140ADED201F0F34416F324DE2A72CF75AE2287431E289015FA2118DC8E271780EEBC8B044E"),
                PasswordSalt = HexToByteArray("4B2A9EAAF28F31D90B1F3C6E03A2F40F405E501BC2E05F5430896198BF4D0440E4BB5DCBD1C30A4F68665DEFDDC6CDA3E929425E0C5EDD53256DAE04398254ADE81A47FCB3BEE0225994BF8C8E90F943D25F4A67D4E33196D2C996F91CD6759073F7AFF9068F05DC7DB154E3F3E6BDDF0E06D5F153D3157A93E13EEF35E069A0"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "nedim",
                Phone = "061110123",
                Status = true,
                RoleId = 3,
                ShiftId=1,
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
