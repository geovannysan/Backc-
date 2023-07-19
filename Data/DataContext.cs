using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Backrest.Data.Models;
using Backrest.Data.Models.Files;
using Backrest.Data.Models.Contifico;
using Backrest.Models;

namespace Backrest.Data
{
    public class DataContext : DbContext
    {
        //"Dataconnetion":"Server=64.91.254.86;port=2083;Database=netbot_brisal;User Id=netbot_concolida;Password=concolida1;"
        //Server=portalconc.mssql.somee.com; Database=portalconc; user id=Geovannysan_SQLLogin_1; pwd=gjzx3t3vly;
        //"Dataconnetion":"Server=localhost,1433; Database=Prubatienda; User=sa; Password =mssql1Ipw;TrustServerCertificate=True"//
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            // Aquí definimos la instrucción SQL para crear el procedimiento almacenado

            string sql =
                @"
                 
              CREATE PROCEDURE `Incremento`()
              BEGIN
              UPDATE incrementos SET contadores = contadores+1 WHERE id=1;
              SELECT *  FROM incrementos WHERE id ='1';
              END             
          ";
            string sql1 =
                @"
            
                CREATE PROCEDURE `Incremento1`()
              BEGIN
              UPDATE incrementos SET contadores = contadores+1 WHERE id=2;
              SELECT *  FROM incrementos WHERE id ='2';
              END
             
          ";
            string sql2 =
                @"              
             
                CREATE PROCEDURE `Incremento3`()
              BEGIN
              UPDATE incrementos SET contadores = contadores+1 WHERE id=3;
              SELECT *  FROM incrementos WHERE id ='3';
              END
          ";

            // Ejecutamos la instrucción SQL para crear el procedimiento almacenado
            //this.Database.ExecuteSqlRaw(sql2);
            //this.Database.ExecuteSqlRaw(sql1);
            //this.Database.ExecuteSqlRaw(sql2);
        }

        public DbSet<Empleado>? Empleado { get; set; } = null;

        //public virtual DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Users>? admins { get; set; } = null;
        public DbSet<Usuario>? admin { get; set; } = null;
        public DbSet<Cargos>? Cargos { get; set; } = null;
        public DbSet<FilesClass>? bancoscon { get; set; } = null;
        public DbSet<Transacciones>? transacion { get; set; } = null;
        public DbSet<Repostressum>? Reporte { get; set; } = null;
        public DbSet<IncrementoClass>? incrementos { get; set; }
        public DbSet<migratio>? migratios {get;set;}
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repostressum>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<Usuario>().HasIndex(n => n.cedula).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
