using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite.Features;
using fakestoreapi.domain.Entities;
using System.Diagnostics.Metrics;
using NetTopologySuite;

namespace rootrooot.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\coskun;Database=rootrootDb;Trusted_Connection=True;MultipleActiveResultSets=true",
                 x => x.UseNetTopologySuite())
             .UseLoggerFactory(MyLoggerFactory);

          


            base.OnConfiguring(optionsBuilder);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            modelBuilder.Entity<Settlement>()
                .HasData(
                    new List<Settlement>()
                    {
                new Settlement(){Id = 1,Country="Netherlands", City_iata="AMS",Name = "Amsterdam", City = "Amsterdam",Iata="AMS", Timezone_region_name="Europe/Amsterdam",Country_iata="NL",Rating=3,Type="airport",Hub= 7,Location = geometryFactory.CreatePoint(new Coordinate(69.9388777, 18.4839233))},
                new Settlement(){Id = 2,Country="Brazil", City_iata="SMP",Name = "Hetron", City = "Santo PAULO",Iata="LRD", Timezone_region_name="America/SauPaulo",Country_iata="BR",Rating=4,Type="airport",Hub=8,Location = geometryFactory.CreatePoint(new Coordinate(69.9388777, 18.4839233))},
                new Settlement(){Id = 3,Country="Turkey", City_iata="SAP",Name = "Istanbul", City = "Istanbul",Iata="SAP", Timezone_region_name="Europe/Istanbul",Country_iata="TR",Rating=5,Type="airport",Hub= 9,Location = geometryFactory.CreatePoint(new Coordinate(69.9388777, 18.4839233))},
                new Settlement(){Id = 4,Country="England", City_iata="LND",Name = "London", City = "London",Iata="LND", Timezone_region_name="Europe/London",Country_iata="IN",Rating=6,Type="airport",Hub=6,Location = geometryFactory.CreatePoint(new Coordinate(69.9388777, 18.4839233))},
                new Settlement(){Id = 5,Country="Canada", City_iata="MNT",Name = "Montreal", City = "Montreal",Iata="MNT", Timezone_region_name="America/Montreal",Country_iata="CA",Rating=7,Type="airport",Hub= 4,Location = geometryFactory.CreatePoint(new Coordinate(69.9388777, 18.4839233))},



                    });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Settlement> Settlement { get; set; }
        
    }
}

