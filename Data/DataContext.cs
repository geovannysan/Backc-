using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Backrest.Data.Models;
using Backrest.Data.Models.Files;
using Backrest.Data.Models.Contifico;

namespace Backrest.Data
{
    public class DataContext : DbContext
    {
        //"Dataconnetion":"Server=64.91.254.86;port=2083;Database=netbot_brisal;User Id=netbot_concolida;Password=concolida1;"
        //Server=portalconc.mssql.somee.com; Database=portalconc; user id=Geovannysan_SQLLogin_1; pwd=gjzx3t3vly;
        //"Dataconnetion":"Server=localhost,1433; Database=Prubatienda; User=sa; Password =mssql1Ipw;TrustServerCertificate=True"//
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<Empleado>? Empleado { get; set; } = null;
        public virtual DbSet<Users>? admins { get; set; } = null;
        public virtual DbSet<Cargos>? Cargos { get; set; } = null;
        public virtual DbSet<FilesClass>? bancoscon { get; set; } = null;
        public virtual DbSet<Transacciones>? transacion { get; set; } = null;
        public virtual DbSet<Repostressum>? Reporte { get; set; } = null;
        public virtual DbSet<IncrementoClass>? incrementos {get;set;}
        public virtual DbSet<Cuentacon>?admin{get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repostressum>(entity =>
            {
                entity.HasNoKey();
            });
         
        }
    }
}
