using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Models
{
    public class Carro : BaseEntidade
    {
        public string Modelo { get; set; }
        public bool Blindagem { get; set; }
        public int Portas { get; set; }
        public string Cor { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public Combustivel TipoCombustivel { get; set; }
        public Cambio TipoCambio { get; set; }

        public int MontadoraCodigo { get; set; }
        public virtual Montadora Montadora { get; set; }
    }

    public enum TipoVeiculo
    {
        Leve,
        Medio,
        Pesado
    }

    public enum Combustivel
    {
        Alcool,
        Diesel,
        GasNatural,
        Gasolina,
        Flex
    }

    public enum Cambio
    {
        Automatico,
        AutomaticoSequencial,
        Cvt,
        Manual,
        SemiAutomatico
    }
}