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
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = "Zaposlenik", Description = "Evidencija prisutnih, rezervacija i tretmana" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = "Korisnik", Description = "Korisnik" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 4, Name = "Trener", Description = "Trener" });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 5, Name = "Masazer", Description = "Masazer" });


            //Shifts
            modelBuilder.Entity<Shift>().HasData(new Shift { Id = 1, Name ="Admin/Member", WorkingHours=" " });
            modelBuilder.Entity<Shift>().HasData(new Shift { Id =2, Name ="Prva smjena", WorkingHours="08:00 - 14:00" });
            modelBuilder.Entity<Shift>().HasData(new Shift { Id = 3, Name ="Druga smjena", WorkingHours="14:00 - 20:00" });

            //MemberShipTypes
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 1, Name ="Mjesecna", Description="Opis mjesecne clanarine.", Duration=30, Price=60 });
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 2, Name ="Tromjesecna", Description="Opis tromjesecne clanarine", Duration=90, Price=180 });
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 3, Name ="Polugodisna", Description="Opis polugodisne clanarine", Duration=180, Price=300 });
            modelBuilder.Entity<MembershipType>().HasData(new MembershipType { Id = 4, Name ="Godisnja", Description="Opis godisnje clanarine", Duration=365, Price=500 });

            //Categories
            modelBuilder.Entity<Category>().HasData(new Category { Id=1, Name="Kategorija jedan", Description="Opis kategorije jedan" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=2, Name="Kategorija dva", Description="Opis kategorije dva" });
            modelBuilder.Entity<Category>().HasData(new Category { Id=3, Name="Kategorija tri", Description="Opis kategorije tri" });

            //TreatmentTypes
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=1, Name="Tip tretman jedan", Description="Opis tipa tretmana jedan" });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=2, Name="Tip tretmana dva", Description="Opis tipa tretmana dva" });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id=3, Name="Tip tretmana tri", Description="Opis tipa tretmana tri" });

            //Treatments

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 1,
                Name = "Tretman lica jedan",
                TreatmentTypeId = 1,
                CategoryId = 1,
                Description = "Opis tretmana lica jedan",
                Duration = 120,
                Price = 120,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica1.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 2,
                Name = "Tretman lica dva",
                TreatmentTypeId = 2,
                CategoryId = 2,
                Description = "Opis  tretmana lica dva",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica2.jpg")
            });
            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 3,
                Name = "Tretman lica tri",
                TreatmentTypeId = 2,
                CategoryId = 2,
                Description = "Opis  tretmana lica tri",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica3.jpg")
            });
            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 4,
                Name = "Tretman lica cetri",
                TreatmentTypeId = 1,
                CategoryId = 1,
                Description = "Opis  tretmana lica cetri",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica4.jpg")
            });
            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 5,
                Name = "Tretman lica pet",
                TreatmentTypeId = 3,
                CategoryId = 1,
                Description = "Opis  tretmana lica pet",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica5.jpg")
            });
            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 6,
                Name = "Tretman lica sest",
                TreatmentTypeId = 1,
                CategoryId =2,
                Description = "Opis  tretmana lica sest",
                Duration = 45,
                Price = 30,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica5.jpg")
            });




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
                FirstName = "Zaposlenik",
                LastName = "Zaposlenik",
                Email = "employee@admin.com",
                PasswordHash = HexToByteArray("0x6F8D511EF54DA2CA269CB4797A3B8052D7F757288E4F413F3F2C130FD9FF85A6341061AAF594F20F69DED9CE6DFA618AC909B67C60349E2BC80EF8BF480D2372"),
                PasswordSalt = HexToByteArray("0xADB638E16237D57B09654217FF8DE3E761BA1E18A29211E81821279FE9E8D3124313A05E4C1B873823DCAF1FA3070DCA913711E7BE5665AA7B7FB0AAD32E34D2676E69B78A20541C9477355C4CD014BC877FB4DFCEECA060816BEB5770950D949A292A3EFBB30641DDE21A00D204ACD5F06073953293E3426FAE3AD1D65EF067"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "zaposlenik",
                Phone = "061112333",
                Status = true,
                RoleId = 2,
                ShiftId=2,
                Picture=ConvertImageToByteArray("wwwroot", "donatelo.jpg")
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                FirstName = "Trener",
                LastName = "Trener",
                Email = "member@member.com",
                PasswordHash = HexToByteArray("0xB7C4947F10280F80E6B3B2C48AB849C9F07449C433C66DA4AA79C9C2419D3431C4C9623D8A91F3ABAB8D89AFD2F14CD8DF5F2B09B3A6DF0066A79DF3BDFD4BC9"),
                PasswordSalt = HexToByteArray("0x755A04682B60A3AA91A4C3E4393CEF9CC55E4EF13E5D560BF815BD10E80282D9B2E79E58EDC2464AE19087C8B69671B83B858843613CAA433988D024A77F518512F978D69802E524188DF5A2D03638568D58F60D5E002541C8FC5BC2B1E39A71D9CCC05D4F40986D1984299D887B5099312DAF72B01D77590ABE78E6D2A6733A"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "trener",
                Phone = "061110121",
                Status = true,
                RoleId = 4,
                ShiftId=1,
                Picture=ConvertImageToByteArray("wwwroot", "splinter.jpg")
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "Korisnik",
                LastName = "Korisnik",
                Email = "korisnik@korisnik.com",
                PasswordHash = HexToByteArray("0xAA483434B7BB1BD1A189FC3B8AA81B8C0EAB71F9416A40A52C4087989EDF49BA17BB8C4DFBA19007C0EF93CD5DA52D544D950BB6509181E5BB20B0782D3D4821"),
                PasswordSalt = HexToByteArray("0xB0951D72CC15473EF80A72C2EBE7473DB8E9263BD9DE87A2E2B6D38850324676FD827BAD25BB47F190690E7B413DF1A9DE546D6D7B62922A35D1E036CED8E88312A8DBC51D441AEDFE39F714483A8ECEBC7D21CF66A9CADFB3F19984546C21E776E42E7F69CA204F7F7779CCC5EDB33289DCE65C96CF846EFC90BC98F9937352"),
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





            //Memberships
            modelBuilder.Entity<Membership>().HasData(new Membership
            {
                Id=1,
                ExpirationDate="03.03.2025",
                StartDate="03.03.2024",
                Status=true,
                UserId=5,
                MemberShipTypeId=4
            });
            modelBuilder.Entity<Membership>().HasData(new Membership
            {
                Id=2,
                ExpirationDate="03.09.2024",
                StartDate="03.03.2024",
                Status=true,
                UserId=4,
                MemberShipTypeId=3
            });



            //Transactions
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id=1,
                PaymentMethod="Stripe",
                Amount=500,
                MemberShipTypeId=4,
                UserId=5,
                Currency="BAM",
                Timestamp=DateTime.UtcNow,

            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id=2,
                PaymentMethod="Stripe",
                Amount=300,
                MemberShipTypeId=3,
                UserId=4,
                Currency="BAM",
                Timestamp=DateTime.UtcNow,

            });

            //Reservations

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=1,
                UserId=5,
                Date="04.03.2024",
                Time="09:00",
                Status=null,
                TreatmentId=2

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=2,
                UserId=5,
                Date="24.04.2024",
                Time="18:00",
                Status=null,
                TreatmentId=3

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=3,
                UserId=5,
                Date="04.04.2024",
                Time="13:00",
                Status=null,
                TreatmentId=2

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=4,
                UserId=4,
                Date="04.04.2024",
                Time="18:00",
                Status=null,
                TreatmentId=2

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=5,
                UserId=5,
                Date="04.07.2024",
                Time="09:00",
                Status=null,
                TreatmentId=2

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=6,
                UserId=5,
                Date="24.04.2024",
                Time="11:00",
                Status=null,
                TreatmentId=2

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=7,
                UserId=5,
                Date="24.03.2024",
                Time="13:00",
                Status=null,
                TreatmentId=3

            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=8,
                UserId=5,
                Date="09.04.2024",
                Time="18:00",
                Status=null,
                TreatmentId=5

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




        private byte[] ConvertImageToByteArray(string folder, string imageName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(currentDirectory, folder, imageName);


            try
            {
                if (File.Exists(imagePath))
                {
                    return File.ReadAllBytes(imagePath);
                }
                else
                {
                    Console.WriteLine("Image file not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }






    }
}
