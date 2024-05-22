using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.CheckConstraints;
using System.ComponentModel.DataAnnotations; // Add this line

namespace Repository.Data
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string id_banco { get; set; }

        [Required]
        [MinLength(3)]
        public string nombre { get; set; }

        [Required]
        [MinLength(3)]
        public string apellido { get; set; }

        [Required]
        [MinLength(3)]
        public string documento { get; set; }

        public string direccion { get; set; }
        public string mail { get; set; }

        [StringLength(10)]
        [RegularExpression("^[0-9]+$")]
        public string celular { get; set; }

        public string estado { get; set; }
    }
}