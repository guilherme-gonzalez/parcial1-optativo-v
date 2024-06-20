using System;
using System.ComponentModel.DataAnnotations;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int Id { get; set; }

        [Required]
        public string id_cliente { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{6}$")]
        public string nro_factura { get; set; }

        [Required]
        public string fecha_hora { get; set; }

        [Required]
        public decimal total { get; set; }

        [Required]
        public decimal total_iva5 { get; set; }

        [Required]
        public decimal total_iva10 { get; set; }

        [Required]
        public decimal total_iva { get; set; }

        [Required]
        [MinLength(6)]
        public string total_letras { get; set; }

        public string sucursal { get; set; }
    }
}