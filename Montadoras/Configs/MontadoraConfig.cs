using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class MontadoraConfig: EntityTypeConfiguration<Montadora>
    {
        public MontadoraConfig()
        {
            ToTable("Montadoras");

            HasKey(k => k.Codigo);

            Property(p => p.RazaoSocial)
                .HasMaxLength(250)
                .IsRequired();
            Property(p => p.NomeFantasia)
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.Nacionalidade)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}