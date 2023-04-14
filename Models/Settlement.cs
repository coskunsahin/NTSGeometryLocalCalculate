using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.domain.Entities
{
    public class Settlement 
    {


        [Key]
        public int Id { get; set; }
        public string? Country { get;set; }
        public string? City { get;set; }
        public string? City_iata { get;set; }
        public string? Iata { get;set; }
        public string? Timezone_region_name { get;set; }
        public string? Country_iata { get; set; }
        public int Rating { get; set; }
        public  string? Name { get; set; }

        public string? Type { get; set; }
        public int Hub { get; set; }
       
        public Geometry? Location { get; set; }


    }
}
