using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidades;
using Logica;


namespace ServicioWeb.Controllers
{
    public class TareasController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get(string estado)
        {
            if (ConvertirATareaServicio(LogicaPrincipal.Instance.FiltrarTareas(estado)) != null)
            {
                return Ok(ConvertirATareaServicio(LogicaPrincipal.Instance.FiltrarTareas(estado)));
            }
            return NotFound();
        }

        // GET api/values/5
        public IHttpActionResult GetIDTarea(int id)
        {
            List<TareaServicio> tareas = ConvertirATareaServicio(LogicaPrincipal.Instance.FiltrarTareas(""));
            if (tareas.Exists(x => x.IDPedido == id))
            {
                return Ok(tareas.Find(x => x.IDPedido == id));
            }
            return NotFound();
        }

        // POST api/values
        [Route("NuevaTarea")]
        public IHttpActionResult POST([FromBody] TareaServicio tareaServ)
        {
            if (ModelState.IsValid)
            {
                Tarea tareaLog = ConvertirATareaLogica(tareaServ);
                if (LogicaPrincipal.Instance.CrearTarea(tareaLog.IDPedido, tareaLog.CostoMateriales, tareaLog.CostoManoDeObra) != null)
                {
                    return Ok(LogicaPrincipal.Instance.CrearTarea(tareaLog.IDPedido, tareaLog.CostoMateriales, tareaLog.CostoManoDeObra));
                }
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        public IHttpActionResult PutTarea(int id)
        {
            List<TareaServicio> tareas = ConvertirATareaServicio(LogicaPrincipal.Instance.FiltrarTareas(""));
            if (tareas.Exists(x => x.IDPedido == id))
            {
                LogicaPrincipal.Instance.ActualizarTarea(id);
                return Ok();
            }
            return NotFound();
        }
        public List<TareaServicio> ConvertirATareaServicio(List<Tarea> tareas)
        {
            return tareas.Select(x => new TareaServicio { CostoManoDeObra = x.CostoManoDeObra, CostoMateriales = x.CostoMateriales, Estado = x.Estado, IDPedido = x.IDPedido }).ToList();
        }
        public Tarea ConvertirATareaLogica(TareaServicio tareaServicio)
        {
            return new Tarea() { IDPedido = tareaServicio.IDPedido, Estado = tareaServicio.Estado, CostoManoDeObra = tareaServicio.CostoManoDeObra, CostoMateriales = tareaServicio.CostoMateriales };
        }
    }
    public class TareaServicio
    {
        [Required]
        public int IDPedido { get; set; }
        [Required]
        public decimal CostoMateriales { get; set; }
        [Required]
        public decimal CostoManoDeObra { get; set; }
        public decimal CostoTotal
        {
            get { return CostoManoDeObra + CostoMateriales; }
        }
        public string Estado { get; set; }
    }
}
