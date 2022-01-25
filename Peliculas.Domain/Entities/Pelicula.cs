using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peliculas.Domain.Entities
{
    public class Pelicula
    {
        public int idPelicula { get; set; }
        public string nombrePelicula { get; set; }
        public string directorPelicula { get; set; }
        public string generoPelicula { get; set; }
        public int calfPelicula { get; set; }
        public int puntPelicula { get; set; }
        public int anoPelicula { get; set; }
    }
}