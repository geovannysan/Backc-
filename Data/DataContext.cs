using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using  Microsoft.EntityFrameworkCore.Metadata;
using Backrest.Data.Models;

namespace Backrest.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }
        public virtual DbSet<Empleado> Empleado { get; set; } = null;
        public virtual DbSet<Cargos> Cargos {get;set;}=null;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        
    }

}