using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int Id { get; set; }
        public string id_cliente { get; set; }
        public string nro_factura { get; set; }
        public DateTime fecha_hora { get; set; }
        public decimal total { get; set; }
        public decimal total_iva5 { get; set; }
        public decimal total_iva10 { get; set; }
        public decimal total_iva { get; set; }
        public string total_letras { get; set; }
        public string sucursal { get; set; }

    }
}