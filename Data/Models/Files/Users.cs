using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Backrest.Data.Models.Files
{
    public class Users
    {
        [Key]
        public string? cl_id { get; set; }

        public string cl_nombre{ get; set; } = null!;

        public string cl_apellido { get; set; } = null!;




    }
}