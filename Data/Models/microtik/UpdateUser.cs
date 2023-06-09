using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backrest.Data.Models.microtik
{
    public class UpdateUser
    {
        [Required]
        public string? idcliente { get; set; }

      //  [Required]
       // public string? nombre { get; set; }

        [Required]
        public string? correo { get; set; }

        [Required]
        public string? telefono { get; set; }

        [Required]
        public string? movil { get; set; }

        //[Required]
       // public string? cedula { get; set; }

       // [Required]
        //public string? codigo { get; set; }

       // [Required]
       // public string? direccion_principal { get; set; }
    }
}
