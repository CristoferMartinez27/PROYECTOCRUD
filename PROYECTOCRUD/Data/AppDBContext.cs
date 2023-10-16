using PROYECTOCRUD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PROYECTOCRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base("AsignacionContext")
        { 
        }

        public DbSet<Usuario> usuarios { get; set; }
    }
}