using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using  Microsoft.EntityFrameworkCore.Metadata;

using Backrest.Data;
using Backrest.Data.Models;
using Backrest.Data.Models.Files;

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
        public virtual DbSet<Empleado>? Empleado { get; set; } = null;
        public virtual DbSet<Cargos>? Cargos {get;set;}=null;
        public virtual DbSet<Users>? admin {get;set;}= null;
        public virtual DbSet<FilesClass>bancoscon{get;set;}
        public virtual DbSet<Transacciones>Trnasacion  {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        
    }

}