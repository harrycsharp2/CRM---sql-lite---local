using CRMwpf.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows.Controls;

namespace CRMwpf.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<client> client { get; set; }
        public DbSet<Money> money { get; set; }
        public DbSet<debt> debt { get; set; }
        public DbSet<business> business { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}