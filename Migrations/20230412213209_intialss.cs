using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class intialss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settlement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_iata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timezone_region_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_iata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hub = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<Geometry>(type: "geography", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlement", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Settlement",
                columns: new[] { "Id", "City", "City_iata", "Country", "Country_iata", "Hub", "Iata", "Location", "Name", "Rating", "Timezone_region_name", "Type" },
                values: new object[,]
                {
                    { 1, "Amsterdam", "AMS", "Netherlands", "NL", 7, "AMS", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (69.9388777 18.4839233)"), "Amsterdam", 3, "Europe/Amsterdam", "airport" },
                    { 2, "Santo PAULO", "SMP", "Brazil", "BR", 8, "LRD", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (69.9388777 18.4839233)"), "Hetron", 4, "America/SauPaulo", "airport" },
                    { 3, "Istanbul", "SAP", "Turkey", "TR", 9, "SAP", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (69.9388777 18.4839233)"), "Istanbul", 5, "Europe/Istanbul", "airport" },
                    { 4, "London", "LND", "England", "IN", 6, "LND", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (69.9388777 18.4839233)"), "London", 6, "Europe/London", "airport" },
                    { 5, "Montreal", "MNT", "Canada", "CA", 4, "MNT", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (69.9388777 18.4839233)"), "Montreal", 7, "America/Montreal", "airport" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settlement");
        }
    }
}
