using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backrest.Data.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        public string? username { get; set; }
        public string? cedula { get; set; }
        public string? password { get; set; }
        public string? imag { get; set; }
        public string? repuestauno { get; set; }
        public string? respuestados { get; set; }
        public string? respuestatres { get; set; }


    }
}