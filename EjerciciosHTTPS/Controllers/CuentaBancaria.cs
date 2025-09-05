using EjerciciosHttps.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//ejercicio 15
namespace EjerciciosHTTPS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaBancariaController : ControllerBase
    {
        private static CuentaBancaria cuenta = new CuentaBancaria(100); // saldo inicial

       
        [HttpPost("depositar")]
        public IActionResult Depositar([FromBody] dynamic data)
        {
            decimal monto = data.GetProperty("monto").GetDecimal();

            bool exito = cuenta.Depositar(monto);

            if (!exito) return BadRequest("El monto debe ser mayor a 0");

            return Ok(new { mensaje = "Depósito exitoso", saldo = cuenta.Saldo });
        }
    }
}

