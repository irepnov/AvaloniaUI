using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public sealed class PgApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseNpgsql("Host=localhost;Port=5432;Database=avalonia;Username=user;Password=user");
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Company> Companys { get; set; }
       // public PgApplicationContext(DbContextOptions<PgApplicationContext> options) : base(options) { }
    }

}
