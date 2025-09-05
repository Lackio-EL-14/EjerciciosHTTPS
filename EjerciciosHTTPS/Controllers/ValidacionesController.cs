using EjerciciosHttps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//Ejercicios 21, 22 , 23 ,24  - Manejo de errores y excepciones en ASP.NET Core
namespace EjerciciosHTTPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidacionesController : ControllerBase
    {
        [HttpGet("validar-edad/{edad}")]
        public IActionResult ValidarEdad(int edad)
        {
            if (edad < 18)
                return BadRequest(new { error = "La edad debe ser mayor o igual a 18" });

            return Ok(new { mensaje = "Edad válida" });
        }

        [HttpGet("dividir/{a}/{b}")]
        public IActionResult Dividir(int a, int b)
        {
            try
            {
                int resultado = a / b;
                return Ok(new { resultado });
            }
            catch (DivideByZeroException)
            {
                return BadRequest(new { error = "No se puede dividir entre cero" });
            }
        }

        [HttpGet("lanzar-error")]
        public IActionResult LanzarError()
        {
            throw new MiExcepcion("Este es un error personalizado lanzado por MiExcepcion");
        }

        [HttpPost("validar-usuario")]
        public IActionResult ValidarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new { mensaje = "Usuario válido", usuario });
        }


    }


}
