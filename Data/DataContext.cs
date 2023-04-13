using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Backrest.Data.Models;
using Backrest.Data.Models.Files;

namespace Backrest.Data
{
    public class DataContext : DbContext
    {
        //Server=portalconc.mssql.somee.com; Database=portalconc; user id=Geovannysan_SQLLogin_1; pwd=gjzx3t3vly;
        //"Dataconnetion":"Server=localhost,1433; Database=Prubatienda; User=sa; Password =mssql1Ipw;TrustServerCertificate=True"//
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public virtual DbSet<Empleado>? Empleado { get; set; } = null;
        public virtual DbSet<Cargos>? Cargos { get; set; } = null;
        public virtual DbSet<FilesClass>? Bancoscon { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }
}
