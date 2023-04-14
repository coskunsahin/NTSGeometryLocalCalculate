using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using rootrooot.Models;
using fakestoreapi.domain.Entities;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using Microsoft.AspNetCore.SignalR;
using NetTopologySuite.Algorithm;
using WebApplication2.Models;
using NetTopologySuite.Operation.Distance;
using Microsoft.Identity.Client;

namespace rootrooot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();
      
        [HttpPost("Find/{iata}")]
        public IActionResult Get( string iata)
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

       
            var myLocation2 = geometryFactory.CreatePoint(new Coordinate(-69.938951, 18.481188));

               

            var Settl = db.Settlement
                 .Where(x => x.Iata == iata)
                .OrderBy(x => x.Location.Distance(myLocation2))


                .Select(x => new
                {
                    name = x.Name,
                    city = x.City,
                    country = x.Country,
                    Iata = x.Iata,
                    Timezone_region_name = x.Timezone_region_name,
                    Country_iata = x.Country_iata,
                    Rating = x.Rating,
                    Type = x.Type,
                    Hub = x.Hub,
                    location = x.Location,



                    Distance = x.Location.Distance(myLocation2)* 0.000621371,
                

                })
                .ToList();



            return Ok(Settl);


        }

      

        [HttpPost]
        public IActionResult GetALL(string iata)
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);


            var myLocation2 = geometryFactory.CreatePoint(new Coordinate(-69.938951, 18.481188));



            var Settl = db.Settlement
                 
                .OrderBy(x => x.Location.Distance(myLocation2))


                .Select(x => new
                {
                    name = x.Name,
                    city = x.City,
                    country = x.Country,
                    Iata = x.Iata,
                    Timezone_region_name = x.Timezone_region_name,
                    Country_iata = x.Country_iata,
                    Rating = x.Rating,
                    Type = x.Type,
                    Hub = x.Hub,
                    location = x.Location,



                    Distance = x.Location.Distance(myLocation2) * 0.000621371,


                })
                .ToList();



            return Ok(Settl);


        }


    }
}
