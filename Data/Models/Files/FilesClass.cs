using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Backrest.Data.Models.Files
{
    public class FilesClass
    {
        [Key]
        public int Id { get; set; }
        public DateTime? fecha { get; set; }

        public string? codigo { get; set; }
        public string? documento { get; set; }
        public string? monto { get; set; }
        public string? oficina { get; set; }
        public string? banco { get; set; }
    }
}
