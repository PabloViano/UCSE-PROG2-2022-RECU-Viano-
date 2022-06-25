using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int ID { get; set; }
        public string NombreSolicitante { get; set; }
        public string NombreArea { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
    public class Tarea
    {
        public int IDPedido { get; set; }
        public decimal CostoMateriales { get; set; }
        public decimal CostoManoDeObra { get; set; }
        public decimal CostoTotal
        {
            get { return CostoManoDeObra + CostoMateriales; }
        }
        public string Estado { get; set; }
    }
}
