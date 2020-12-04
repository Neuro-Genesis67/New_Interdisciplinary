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
                new Admin(1, "Christian", "Hilmer123!"),
                new Admin(2, "Tom", "Hdr76nqn"),
                new Admin(3, "Ingrida", "123"),
                new Admin(4, "t", "t")
            );
        }
    }
}
