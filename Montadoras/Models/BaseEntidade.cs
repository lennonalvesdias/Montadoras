using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Montadoras.Models
{
    public class BaseEntidade
    {
        [Key]
        public int Codigo { get; set; }
    }
}