using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Montadoras.DAO
{
    public class MontadoraDAO
    {
        protected Contexto contexto;

        public MontadoraDAO()
        {
            contexto = new Contexto();
        }

        public void Adicionar(Montadora montadora)
        {
            contexto.Montadoras.Add(montadora);
            contexto.SaveChanges();
        }

        public void Atualizar(Montadora montadora)
        {
            var entry = contexto.Entry(montadora);
            entry.State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public void Remover(Montadora montadora)
        {
            contexto.Montadoras.Remove(montadora);
            contexto.SaveChanges();
        }

        public IList<Montadora> Listar()
        {
            return contexto.Montadoras.ToList();
        }

        public Montadora Buscar(int codigo)
        {
            return contexto.Montadoras.FirstOrDefault(m => m.Codigo == codigo);
        }

        public bool ValidaMontadora(string razaoSocial, string nomeFantasia)
        {
            var listaMontadoras = contexto.Montadoras.ToList();
            var montadora = listaMontadoras.Where(m => m.RazaoSocial.Equals(razaoSocial) || m.NomeFantasia.Equals(nomeFantasia));
            if (montadora.Any())
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}