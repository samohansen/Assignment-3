using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public static class TempStorage
    {
        private static List<MovieFormModel> movies = new List<MovieFormModel>();

        public static IEnumerable<MovieFormModel> Movies => movies;

        public static void AddMovie(MovieFormModel movie)
        {
            movies.Add(movie);
        }
    }
}
