using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class Initializer : DropCreateDatabaseAlways<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {
            var montadora1 = new Montadora
            {
                Codigo = 0,
                RazaoSocial = "General Motors",
                NomeFantasia = "Chevrolet",
                Nacionalidade = "Estados Unidos"
            };

            var montadora2 = new Montadora
            {
                Codigo = 1,
                RazaoSocial = "Fiat Automobiles S.p.A.",
                NomeFantasia = "FIAT",
                Nacionalidade = "Itália"
            };

            contexto.Montadoras.Add(montadora1);
            contexto.Montadoras.Add(montadora2);

            var carro1 = new Carro
            {
                Codigo = 0,
                Modelo = "Corsa",
                Blindagem = false,
                Portas = 4,
                Cor = "Prata",
                TipoVeiculo = TipoVeiculo.Leve,
                TipoCombustivel = Combustivel.Alcool,
                TipoCambio = Cambio.Automatico,
                MontadoraCodigo = 0
            };

            var carro2 = new Carro
            {
                Codigo = 1,
                Modelo = "Uno",
                Blindagem = false,
                Portas = 2,
                Cor = "Vermelho",
                TipoVeiculo = TipoVeiculo.Leve,
                TipoCombustivel = Combustivel.Gasolina,
                TipoCambio = Cambio.Manual,
                MontadoraCodigo = 1
            };

            contexto.Carros.Add(carro1);
            contexto.Carros.Add(carro2);

            base.Seed(contexto);
        }
    }
}