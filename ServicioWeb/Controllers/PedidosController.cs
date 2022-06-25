using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Logica;
using Entidades;

namespace ServicioWeb.Controllers
{
    public class PedidosController : ApiController
    {
        // POST api/<controller>
        public IHttpActionResult Post([FromBody] PedidoServicio pedido)
        {
            if (ModelState.IsValid)
            {
                LogicaPrincipal.Instance.CrearPedido(pedido.NombreSolicitante, pedido.NombreArea, pedido.Descripcion);
                return Ok();
            }
            return BadRequest();
        }
    }
    public class PedidoServicio
    {
        public int ID { get; set; }
        [Required]
        public string NombreSolicitante { get; set; }
        [Required]
        public string NombreArea { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}