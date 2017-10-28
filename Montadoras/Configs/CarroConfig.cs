using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class CarroConfig : EntityTypeConfiguration<Carro>
    {
        public CarroConfig()
        {
            ToTable("Carros");

            HasKey(k => k.Codigo);

            Property(p => p.Modelo)
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.Blindagem)
                .IsRequired();
            Property(p => p.Portas)
                .IsRequired();
            Property(p => p.Cor)
                .HasMaxLength(80)
                .IsRequired();
            Property(p => p.TipoVeiculo)
                .IsRequired();
            Property(p => p.TipoCombustivel)
                .IsRequired();
            Property(p => p.TipoCambio)
                .IsRequired();

            HasRequired(r => r.Montadora)
                .WithMany(m => m.Carros)
                .HasForeignKey(c => c.MontadoraCodigo);
        }
    }
}