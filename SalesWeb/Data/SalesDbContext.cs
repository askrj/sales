using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Models;

namespace SalesWeb.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions options) : base(options){}

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Seller> Sellers  { get; set; }
        public DbSet<SalesRecord> SalesRecords  { get; set; }
    }
}