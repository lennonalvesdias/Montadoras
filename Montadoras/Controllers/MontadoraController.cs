using Montadoras.DAO;
using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadoras.Controllers
{
    public class MontadoraController : Controller
    {
        private readonly MontadoraDAO mdao = new MontadoraDAO();

        // GET: Montadora
        public ActionResult Index()
        {
            IList<Montadora> montadoras = mdao.Listar();
            ViewBag.Montadoras = montadoras;
            return View();
        }

        public ActionResult Formulario(int? codigo)
        {
            Montadora montadora;

            if (codigo != null)
            {
                montadora = mdao.Buscar(codigo.Value);
            } else
            {
                montadora = new Montadora();
            }
            
            ViewBag.Montadora = montadora;
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Montadora montadora)
        {
            if (montadora.Codigo != 0)
            {
                mdao.Atualizar(montadora);
            } else
            {
                if (!mdao.ValidaMontadora(montadora.RazaoSocial, montadora.NomeFantasia))
                {
                    throw new Exception();
                }

                mdao.Adicionar(montadora);
            }

            IList<Montadora> montadoras = mdao.Listar();
            ViewBag.Montadoras = montadoras;
            return View("Index");
        }

        public ActionResult Remover(int codigo)
        {
            Montadora montadora = mdao.Buscar(codigo);
            mdao.Remover(montadora);

            IList<Montadora> montadoras = mdao.Listar();
            ViewBag.Montadoras = montadoras;
            return View("Index");
        }
    }
}