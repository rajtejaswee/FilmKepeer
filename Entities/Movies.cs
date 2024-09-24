using System;
using System.Collections.Generic;

namespace Filmkeeper.Entities
{
	public class Movies
	{
        public int id { get; set; }
        public int yearofRelease { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int ProducerId { get; set; }
        public string Poster { get; set; }
        public List<int> ActorId { get; set; }
        public List<int> GenreId { get; set; }
        public Review Reviews { get; set; }

    }
}

