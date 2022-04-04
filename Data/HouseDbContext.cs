using Microsoft.EntityFrameworkCore;
using System;
using house.Core.Domain;

namespace Data
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options)
            : base(options) { }
        public DbSet<House> House { get; set; }
    }
}
