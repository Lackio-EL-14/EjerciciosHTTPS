using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EjerciciosHttps.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColeccionesController : ControllerBase
    {
   
        // 16. List<T> Dinámica (CRUD)
    
        private static List<string> items = new List<string>();

    
        [HttpPost("agregar-item")]
        public IActionResult AgregarItem([FromBody] string item)
        {
            items.Add(item);
            return Ok(new { mensaje = "Item agregado", items });
        }

   
        [HttpDelete("eliminar-item/{item}")]
        public IActionResult EliminarItem(string item)
        {
            if (!items.Remove(item))
                return NotFound(new { error = "Item no encontrado" });

            return Ok(new { mensaje = "Item eliminado", items });
        }

        [HttpGet("items")]
        public IActionResult ListarItems() => Ok(items);

   
        // 17. Queue<T> para Pedidos
     
        private static Queue<string> pedidos = new Queue<string>();

 
        [HttpPost("encolar-pedido")]
        public IActionResult EncolarPedido([FromBody] string pedido)
        {
            pedidos.Enqueue(pedido);
            return Ok(new { mensaje = "Pedido encolado", pedidos });
        }


        [HttpPost("atender-pedido")]
        public IActionResult AtenderPedido()
        {
            if (pedidos.Count == 0)
                return BadRequest(new { error = "No hay pedidos en la cola" });

            var atendido = pedidos.Dequeue();
            return Ok(new { mensaje = "Pedido atendido", atendido, pedidos });
        }


        // 18. HashSet<T> para Únicos
    
        private static HashSet<int> numeros = new HashSet<int>();

        [HttpPost("agregar-numero")]
        public IActionResult AgregarNumero([FromBody] int numero)
        {
            if (!numeros.Add(numero))
                return BadRequest(new { error = "El número ya existe" });

            return Ok(new { mensaje = "Número agregado", numeros });
        }

        // 19. SortedList<TKey,TValue>
      
        private static SortedList<string, string> paises = new SortedList<string, string>
        {
            { "PE", "Perú" },
            { "CO", "Colombia" },
            { "MX", "México" },
            { "AR", "Argentina" }
        };


        [HttpGet("paises")]
        public IActionResult ObtenerPaises()
        {
            return Ok(paises);
        }

        // 20. LinkedList<T> Historial
      
        private static LinkedList<string> historial = new LinkedList<string>();
        private static LinkedListNode<string>? actual = null;

        // POST api/colecciones/agregar-historial
        [HttpPost("agregar-historial")]
        public IActionResult AgregarHistorial([FromBody] string pagina)
        {
            historial.AddLast(pagina);
            actual = historial.Last;
            return Ok(new { mensaje = "Página agregada", historial });
        }

     
        [HttpGet("avanzar")]
        public IActionResult Avanzar()
        {
            if (actual?.Next == null)
                return BadRequest(new { error = "No hay más páginas adelante" });

            actual = actual.Next;
            return Ok(new { mensaje = "Página actual", pagina = actual.Value });
        }

        
        [HttpGet("retroceder")]
        public IActionResult Retroceder()
        {
            if (actual?.Previous == null)
                return BadRequest(new { error = "No hay más páginas atrás" });

            actual = actual.Previous;
            return Ok(new { mensaje = "Página actual", pagina = actual.Value });
        }
    }
}
