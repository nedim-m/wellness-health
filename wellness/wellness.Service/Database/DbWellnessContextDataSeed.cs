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
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Masaže", Description = "Različite vrste masaža za opuštanje i relaksaciju tela." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Tretmani lica", Description = "Raznovrsni tretmani za negu lica i kože." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Tretmani tela", Description = "Različite usluge za tretiranje tela i poboljšanje izgleda kože." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Relaksacija", Description = "Prostor za opuštanje, sauna, đakuzi i meditacija." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Name = "Nail Bar", Description = "Usluge za negu noktiju, manikir i pedikir." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 6, Name = "Fitnes i Wellness", Description = "Teretana, grupni treninzi i wellness programi." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 7, Name = "Estetski tretmani", Description = "Depilacija, tretmani za kožu i maderoterapija." });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 8, Name = "Kategorija za brisanje", Description = "Moguće pobrisati jer nema veze sa tretmanima" });


            //TreatmentTypes
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 1, Name = "Klasična masaža", Description = "Osnovna masaža za opuštanje mišića." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 2, Name = "Masaža sa toplim kamenjem", Description = "Masaža koja koristi tople kamene da opusti mišiće." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 3, Name = "Masaža aromaterapijom", Description = "Masaža sa mirisnim uljima za dodatnu relaksaciju." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 4, Name = "Thai masaža", Description = "Tradicionalna thai masaža za poboljšanje fleksibilnosti." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 5, Name = "Hidratacija kože", Description = "Tretman za hidrataciju i osveženje kože lica." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 6, Name = "Čišćenje lica", Description = "Dubinsko čišćenje lica radi uklanjanja nečistoća." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 7, Name = "Tretmani oblikovanja tela", Description = "Usluge za oblikovanje tela i smanjenje obima." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 8, Name = "Piling tela", Description = "Piling za uklanjanje odumrlih ćelija kože." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 9, Name = "Sauna", Description = "Suva sauna za detoksikaciju tela." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 10, Name = "Manikir", Description = "Nega noktiju na rukama." });
            modelBuilder.Entity<TreatmentType>().HasData(new TreatmentType { Id = 11, Name = "Tip tretmana za brisanje", Description = "Moguće pobrisati jer nema veze sa tretmanima" });



            //Treatments

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 1,
                Name = "Relaksaciona masaža",
                TreatmentTypeId = 1,
                CategoryId = 1, 
                Description = "Masaža koja opušta telo i um.",
                Duration = 60,
                Price = 80,
                Picture = ConvertImageToByteArray("wwwroot", "relaksaciona-masaza.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 2,
                Name = "Tretman lica sa hidratacijom",
                TreatmentTypeId = 2, 
                CategoryId = 2, 
                Description = "Tretman za hidrataciju kože lica.",
                Duration = 45,
                Price = 60,
                Picture = ConvertImageToByteArray("wwwroot", "tretman-lica-hidratacija.jpg")
            });

       

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 3,
                Name = "Anticelulit tretman",
                TreatmentTypeId = 3,
                CategoryId = 3, 
                Description = "Tretman koji cilja na smanjenje celulita.",
                Duration = 60,
                Price = 100,
                Picture = ConvertImageToByteArray("wwwroot", "anticelulit-tretman.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 4,
                Name = "Mediteranski piling",
                TreatmentTypeId = 4, 
                CategoryId = 4, 
                Description = "Piling sa sastojcima inspirisanim mediteranskom kuhinjom.",
                Duration = 45,
                Price = 75,
                Picture = ConvertImageToByteArray("wwwroot", "mediteranski-piling.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 5,
                Name = "Aromaterapija",
                TreatmentTypeId = 5, 
                CategoryId = 4, 
                Description = "Tretman sa mirisnim uljima za potpunu relaksaciju.",
                Duration = 90,
                Price = 120,
                Picture = ConvertImageToByteArray("wwwroot", "aromaterapija.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 6,
                Name = "Manikir i pedikir",
                TreatmentTypeId = 6,
                CategoryId = 5, 
                Description = "Kompletna nega noktiju na rukama i nogama.",
                Duration = 75,
                Price = 70,
                Picture = ConvertImageToByteArray("wwwroot", "manikir-pedikir.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 7,
                Name = "Yoga sesija",
                TreatmentTypeId = 7, 
                CategoryId = 6, 
                Description = "Sesija joge za fizičko i mentalno blagostanje.",
                Duration = 60,
                Price = 50,
                Picture = ConvertImageToByteArray("wwwroot", "yoga-sesija.jpg")
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                Id = 8,
                Name = "Tretman za brisanje",
                TreatmentTypeId = 7,
                CategoryId = 6,
                Description = "Ovaj tretman je moguće obrisati jer nema povezanosti sa rezervacijama",
                Duration = 60,
                Price = 50,
                Picture = ConvertImageToByteArray("wwwroot", "yoga-sesija.jpg")
            });





            //Users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "admin",
                Phone = "061399222",
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
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "zaposlenik",
                Phone = "061162333",
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
                Phone = "061440121",
                Status = true,
                RoleId = 4,
                ShiftId=3,
      
            });

 

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                FirstName = "Nedim",
                LastName = "Misic",
                Email = "nedim_misic@hotmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "nedim",
                Phone = "061110123",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 5,
                FirstName = "Korisnik",
                LastName = "Korisnik",
                Email = "user.2.wellness2024@gmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "korisnik",
                Phone = "061810123",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 6,
                FirstName = "Masazer",
                LastName = "Masazer",
                Email = "masazer@member.com",
                PasswordHash = HexToByteArray("0xB7C4947F10280F80E6B3B2C48AB849C9F07449C433C66DA4AA79C9C2419D3431C4C9623D8A91F3ABAB8D89AFD2F14CD8DF5F2B09B3A6DF0066A79DF3BDFD4BC9"),
                PasswordSalt = HexToByteArray("0x755A04682B60A3AA91A4C3E4393CEF9CC55E4EF13E5D560BF815BD10E80282D9B2E79E58EDC2464AE19087C8B69671B83B858843613CAA433988D024A77F518512F978D69802E524188DF5A2D03638568D58F60D5E002541C8FC5BC2B1E39A71D9CCC05D4F40986D1984299D887B5099312DAF72B01D77590ABE78E6D2A6733A"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "masazer",
                Phone = "061110191",
                Status = true,
                RoleId = 5,
                ShiftId=2,

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 7,
                FirstName = "Employee",
                LastName = "Employee",
                Email = "employee@member.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "employee",
                Phone = "061618333",
                Status = true,
                RoleId = 2,
                ShiftId=2,
                Picture=ConvertImageToByteArray("wwwroot", "splinter.jpg")
            });


            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 8,
                FirstName = "Neko",
                LastName = "Nekic",
                Email = "neko@gmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "neko",
                Phone = "065118123",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 9,
                FirstName = "Test",
                LastName = "Test",
                Email = "test@gmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "test",
                Phone = "066999993",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 10,
                FirstName = "User",
                LastName = "User",
                Email = "user@gmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "user",
                Phone = "066999993",
                Status = true,
                RoleId = 3,
                ShiftId=1,
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 11,
                FirstName = "Ime",
                LastName = "Prezime",
                Email = "ime@gmail.com",
                PasswordHash = HexToByteArray("0xE82F9D33958051FB08CF22F9C66ADAD2BBBEDA0BF8A3251BFF99D70862BB720E7AE1BC033E6733334416E3CA946A75414E390E420E4BB2339B3B810D96F1AA5F"),
                PasswordSalt = HexToByteArray("0x9D3D009C23EBD3BF47F809780D87C78001C20E70410701D9478E4ADFDBD6C1AFA93D5C5AC47EA8E14586DDA0AC7AEAE335375A04BE1E5B453D6EF133798677BC4417AFB030A4B3CEB013DB562B8BF79927F8ED058CF87BFD55AF8622FAEF311BB56B913387B6217C840A0D842F4A907C317B5946A153C72966087B9FDFF8EBCA"),
                RefreshToken = String.Empty,
                TokenCreated = DateTime.UtcNow,
                TokenExpires = DateTime.UtcNow.AddHours(1),
                UserName = "ime",
                Phone = "066944559",
                Status = false,
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
            modelBuilder.Entity<Membership>().HasData(new Membership
            {
                Id=3,
                ExpirationDate="03.09.2024",
                StartDate="03.03.2024",
                Status=true,
                UserId=8,
                MemberShipTypeId=3
            });

            modelBuilder.Entity<Membership>().HasData(new Membership
            {
                Id=4,
                ExpirationDate="03.03.2025",
                StartDate="03.03.2024",
                Status=true,
                UserId=9,
                MemberShipTypeId=4
            });

            modelBuilder.Entity<Membership>().HasData(new Membership
            {
                Id=5,
                ExpirationDate="03.03.2025",
                StartDate="03.03.2024",
                Status=true,
                UserId=10,
                MemberShipTypeId=4
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
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id=3,
                PaymentMethod="PayPal",
                Amount=153.84m,
                MemberShipTypeId=3,
                UserId=8,
                Currency="EUR",
                Timestamp=DateTime.UtcNow,

            });

            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id=4,
                PaymentMethod="Stripe",
                Amount=500,
                MemberShipTypeId=4,
                UserId=9,
                Currency="BAM",
                Timestamp=DateTime.UtcNow,

            });
            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                Id=5,
                PaymentMethod="Stripe",
                Amount=500,
                MemberShipTypeId=4,
                UserId=10,
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

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=9,
                UserId=5,
                Date="04.03.2024",
                Time="11:00",
                Status=true,
                TreatmentId=3

            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=10,
                UserId=4,
                Date="04.03.2024",
                Time="13:00",
                Status=true,
                TreatmentId=2

            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=11,
                UserId=4,
                Date="03.03.2024",
                Time="13:00",
                Status=true,
                TreatmentId=2

            });


            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id=12,
                UserId=4,
                Date="05.03.2024",
                Time="13:00",
                Status=true,
                TreatmentId=1

            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 13,
                UserId = 5,
                Date = "10.03.2024",
                Time = "10:00",
                Status = true,
                TreatmentId = 2
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 14,
                UserId = 5,
                Date = "15.03.2024",
                Time = "12:00",
                Status = false,
                TreatmentId = 5
            });
            
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 15,
                UserId = 4,
                Date = "09.03.2024",
                Time = "09:00",
                Status = true,
                TreatmentId = 3
            });

            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 16,
                UserId = 8,
                Date = "06.03.2024",
                Time = "09:00",
                Status = true,
                TreatmentId = 4
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 17,
                UserId = 9,
                Date = "06.03.2024",
                Time = "11:00",
                Status = true,
                TreatmentId = 5
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 18,
                UserId = 10,
                Date = "06.03.2024",
                Time = "13:00",
                Status = true,
                TreatmentId = 6
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 19,
                UserId = 10,
                Date = "09.03.2024",
                Time = "13:00",
                Status = true,
                TreatmentId = 7
            });
            modelBuilder.Entity<Reservation>().HasData(new Reservation
            {
                Id = 20,
                UserId = 10,
                Date = "07.03.2024",
                Time = "13:00",
                Status = true,
                TreatmentId = 7
            });





            //Ratings
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=1,ReservationId=11,StarRating=4 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=2, ReservationId=10, StarRating=5 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=3, ReservationId=9, StarRating=3 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=4, ReservationId=15, StarRating=3 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=5, ReservationId=13, StarRating=2 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=6, ReservationId=12, StarRating=5 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=7, ReservationId=16, StarRating=5 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=8, ReservationId=17, StarRating=5 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=9, ReservationId=18, StarRating=4 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=10, ReservationId=19, StarRating=4 });
            modelBuilder.Entity<Rating>().HasData(new Rating { Id=11, ReservationId=20, StarRating=4 });


            //Reports
            modelBuilder.Entity<Report>().HasData(new Report
            {
                Id = 1,
                DateFrom = new DateTime(2024, 3, 1),  
                DateTo = new DateTime(2024, 3, 30),    
                EarnedMoney = 1500.00m,
                TotalUsers = 3,
                Timestamp = DateTime.Now,  
                MemberShipTypeId = 4
            });

            modelBuilder.Entity<Report>().HasData(new Report
            {
                Id = 2,
                DateFrom = new DateTime(2024, 3, 1), 
                DateTo = new DateTime(2024, 3, 30),    
                EarnedMoney = 599.99m,
                TotalUsers = 2,
                Timestamp = DateTime.Now, 
                MemberShipTypeId = 3
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
