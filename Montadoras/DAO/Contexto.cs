using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class Contexto : DbContext
    {
        public DbSet<Montadora> Montadoras { get; set; }
        public DbSet<Carro> Carros { get; set; }

        public Contexto()
        {
            Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuider)
        {
            modelBuider.Configurations.Add(new MontadoraConfig());
            modelBuider.Configurations.Add(new CarroConfig());
        }
    }
}