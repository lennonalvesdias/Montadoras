using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Models
{
    public class Montadora : BaseEntidade
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Nacionalidade { get; set; }

        public ICollection<Carro> Carros { get; set; }
    }
}