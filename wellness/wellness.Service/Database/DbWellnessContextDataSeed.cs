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
            modelBuilder.Entity<Role>().HasData(new Role { Id=1, Name="Administrator", Description="Administracija" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=2, Name="Worker-first-shift", Description="Evidencija prisutnih, rezervacija i tretmana", ShiftTime="od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=3, Name="Member", Description="Korisnik" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=4, Name="Worker-second-shift", Description="Evidencija prisutnih, rezervacija i tretmana", ShiftTime="od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=5, Name="Trainer-first-shift", Description="Fitnes trener", ShiftTime="od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=6, Name="Trainer-second-shift", Description="Fitnes trener, rezervacija i tretmana", ShiftTime="od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=7, Name="Physiotherapist-first-shift", Description="Fizijatar", ShiftTime="od 08:00 do 16:00" });
            modelBuilder.Entity<Role>().HasData(new Role { Id=8, Name="Physiotherapist-second-shift", Description="Fizijatar, rezervacija i tretmana", ShiftTime="od 08:00 do 16:00" });
        }
    }
}
