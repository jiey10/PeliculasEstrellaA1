using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Peliculas.Infraestructure.Repositories;
using Peliculas.Domain.Entities;

namespace Peliculas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerPeliculas : ControllerBase
    {
        [HttpGet]
        [Route("Todas_Las_Peliculas")]
        public IActionResult ObtenerTodas()
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            return Ok(peliculas.ObtenerTodas());
        }

        [HttpGet]
        [Route("Buscar_Por_Id")]
        public IActionResult ObtenerPorId (int id)
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            var pelicula = peliculas.ObtenerPorId(id);
            if (pelicula == null)
            {
                return NotFound("Intentalo de nuevo. No se encontro ninguna pelicula.");
            }
            else
            {
                return Ok(pelicula);            
            }
        }

        [HttpGet]
        [Route("Buscar_Por_Director/{director}")]
        public IActionResult BuscarPorDirector(string director)
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            var pelicula = peliculas.BuscarPorDirector(director);
            if (pelicula.Count() == 0)
            {
                return NotFound("El nombre del director ingresado no existe en el sistema. Pruebe con uno que si exista.");
            }
            else
            {
                return Ok(pelicula);
            }
        }


        [HttpPost]
        [Route("Agregar_Pelicula")]
        public IActionResult AgregarPelicula(Pelicula nuevaPelicula)
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            peliculas.AgregarPelicula(nuevaPelicula);
            return CreatedAtAction(nameof(AgregarPelicula), nuevaPelicula);
        }

        [HttpPut]
        [Route("Actualizar_Pelicula")]
        public IActionResult ActualizarPelicula(int id, Pelicula actualizarPelicula)
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            var autentificacion = peliculas.ObtenerPorId(id);
            if(autentificacion == null)
            {
                return NotFound("El ID ingresado no existe en el sistema, prueba con uno que si exista.");
            }
            else
            {
                peliculas.ActualizarPelicula(id, actualizarPelicula);
                return Ok("Actualización correcta.");
            }
        }

        [HttpDelete]
        [Route("Eliminar_Pelicula")]
        public IActionResult EliminarPelicula(int id)
        {
            PeliculasRepositorie peliculas = new PeliculasRepositorie();
            var autentificacion = peliculas.ObtenerPorId(id);
            if(autentificacion == null)
            {
                return NotFound("El ID ingresado no existe en el sistema, prueba con uno que si exista.");
            }
            else
            {
                peliculas.EliminarPelicula(id);
                return Ok("Eliminación correcta.");
            }
        }


    }
}