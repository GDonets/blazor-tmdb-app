using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorOmdbTest.Models
{
    public class MovieFilter
    {
        public int MovieId { get; set; }

        public int CategoryId { get; set; }

        public int ActorId { get; set; }

        public string Name { get; set; }
    }
}
