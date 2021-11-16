using System.Collections.Generic;

namespace NetMovieSearch.DataModels
{
    public class Genre
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres {get;set;}
    }
}
