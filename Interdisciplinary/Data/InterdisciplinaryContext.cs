using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Interdisciplinary.Models;

namespace Interdisciplinary.Data {
    public class InterdisciplinaryContext : DbContext {

        public InterdisciplinaryContext(DbContextOptions<InterdisciplinaryContext> options) : base(options) { }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Show>  Shows  { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Admin>().HasData(
                new Admin { AdminId = 1, Username = "Christian", Password = "Hilmer123!" },
                new Admin { AdminId = 2, Username = "Ingrida", Password = "123" },
                new Admin { AdminId = 3, Username = "Karsten", Password = "skov" },
                new Admin { AdminId = 4, Username = "t", Password = "t" }
            );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Title = "Opera" },
                new Genre { GenreId = 2, Title = "Concert" },
                new Genre { GenreId = 3, Title = "Play" },
                new Genre { GenreId = 4, Title = "Ballet" }
            );

            modelBuilder.Entity<Show>().HasData(
                new Show {
                    ShowId = 1,
                    Title = "La traviata",
                    AvailableTickets = 230,
                    Price = 189,
                    Date = new DateTime(2021, 1, 06),
                    ImageUrl = "https://i.ibb.co/zPGkR3q/la-traviata.png",
                    GenreId = 1,
                    AdminId = 1
                },
                new Show {
                    ShowId = 2,
                    Title = "The four seasons",
                    AvailableTickets = 451,
                    Price = 169,
                    Date = new DateTime(2020, 12, 3),
                    ImageUrl = "https://i.ibb.co/KhKHJv9/the-four-seasons.png",
                    GenreId = 2,
                    AdminId = 2
                }
            );
        }
    }
}
