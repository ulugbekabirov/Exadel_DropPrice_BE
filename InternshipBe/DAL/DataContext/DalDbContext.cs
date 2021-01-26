using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataContext
{
    public class DalDbContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PointOfSale> PointOfSales { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<SavedDiscount> SavedDiscounts { get; set; }
        public DalDbContext(DbContextOptions<DalDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
