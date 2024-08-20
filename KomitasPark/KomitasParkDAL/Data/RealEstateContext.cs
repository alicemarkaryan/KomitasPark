
using KomitasPark.KomitasParkDAL.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace KomitasPark.KomitasParkDAL.Data
{
    public class RealEstateContext : DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<BuildingGroup> BuildingGroups { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Element> Elements { get; set; }
    }
}
