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
        public string? id { get; set; }

        public string username{ get; set; } = null!;

        public string name { get; set; } = null!;




    }
}