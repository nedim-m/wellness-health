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
            modelBuilder.Entity<Role>().HasData(new Role { Id=1, Name="Administrator", Description="This is Administrator Description" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=2, Name="Uposlenik", Description="This is Uposlenik Description" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=3, Name="Korisnik", Description="This is Korisnik Description" });
        }
    }
}
