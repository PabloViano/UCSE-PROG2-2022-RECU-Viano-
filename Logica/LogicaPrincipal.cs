using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Logica
{
    public class LogicaPrincipal
    {
        private static LogicaPrincipal instancia;
        private LogicaPrincipal() { }
        public static LogicaPrincipal Instance
        {
            get { if (instancia != null)
                {
                    return instancia;
                }
                    return instancia = new LogicaPrincipal();  
                }
        }
        private List<Pedido> Pedidos = new List<Pedido>();
        private List<Tarea> Tareas = new List<Tarea>();

        public Pedido CrearPedido(string nombreS, string nombreA, string descripcion)
        {
            if (nombreA == "" || nombreS == "" || descripcion == "")
            {
                return null;
            }
            else
            {
                Pedido pedido = new Pedido() { Descripcion = descripcion, ID = Pedidos.Count + 1, NombreArea = nombreA, NombreSolicitante = nombreS, FechaCreacion = DateTime.Now };
                Pedidos.Add(pedido);
                return pedido;
            }
        }
        public Tarea CrearTarea(int id, decimal costoMat, decimal costoMan)
        {
            if (!Tareas.Exists(x => x.IDPedido == id))
            {
                return null;
            }
            else
            {
                Tarea tarea = new Tarea() { IDPedido = id, CostoManoDeObra = costoMan, CostoMateriales = costoMat, Estado = "PENDIENTE" };
                Tareas.Add(tarea);
                return tarea;
            }
        }
        public List<Tarea> FiltrarTareas(string estado)
        {
            if (estado != "")
            {
                List<Tarea> TareasFiltradas = Tareas.Where(x => x.Estado == estado).ToList();
                if (TareasFiltradas.Count() == 0)
                {
                    return null;
                }
                return TareasFiltradas;
            }
            return Tareas;
        }
        public Tarea ObtenerTareaPorID(int id)
        {
            if (Tareas.Exists(x => x.IDPedido == id))
            {
                return Tareas.Find(x => x.IDPedido == id);
            }
            return null;
        }
        public bool ActualizarTarea(int id)
        {
            if (Tareas.Exists(x => x.IDPedido == id))
            {
                Tareas.Find(x => x.IDPedido == id).Estado = "COMPLETADO";
                return true;
            }
            return false;
        }
    }
}
