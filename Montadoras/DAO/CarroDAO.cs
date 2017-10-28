using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class CarroDAO
    {
        protected Contexto contexto;

        public CarroDAO()
        {
            contexto = new Contexto();
        }

        public void Adicionar(Carro carro)
        {
            contexto.Carros.Add(carro);
            contexto.SaveChanges();
        }

        public void Atualizar(Carro carro)
        {
            var entry = contexto.Entry(carro);
            entry.State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Remover(Carro carro)
        {
            contexto.Carros.Remove(carro);
            contexto.SaveChanges();
        }

        public IList<Carro> Listar()
        {
            return contexto.Carros.ToList();
        }

        public Carro Buscar(int codigo)
        {
            return contexto.Carros.FirstOrDefault(m => m.Codigo == codigo);
        }

        public bool ValidaCarro(string modelo)
        {
            var listaCarros = contexto.Carros.ToList();
            var carro = listaCarros.Where(c => c.Modelo.Equals(modelo));
            if (carro.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}