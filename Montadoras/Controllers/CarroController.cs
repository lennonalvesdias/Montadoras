using Montadoras.DAO;
using Montadoras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Montadoras.Controllers
{
    public class CarroController : Controller
    {
        private readonly CarroDAO cdao = new CarroDAO();
        private readonly MontadoraDAO mdao = new MontadoraDAO();

        // GET: Carro
        public ActionResult Index()
        {
            IList<Carro> carros = cdao.Listar();
            ViewBag.Carros = carros;
            return View();
        }

        public ActionResult Formulario(int? codigo)
        {
            ViewBag.Montadoras = mdao.Listar();

            Carro carro;

            if (codigo != null)
            {
                carro = cdao.Buscar(codigo.Value);
            }
            else
            {
                carro = new Carro();
            }

            ViewBag.Carro = carro;
            
            return View();
        }

        [HttpPost]
        public ActionResult Salvar(Carro carro)
        {
            if (carro.Codigo != 0)
            {
                cdao.Atualizar(carro);
            }
            else
            {
                if (!cdao.ValidaCarro(carro.Modelo))
                {
                    throw new Exception();
                }

                cdao.Adicionar(carro);
            }

            IList<Carro> carros = cdao.Listar();
            ViewBag.Carros = carros;
            return View("Index");
        }

        public ActionResult Remover(int codigo)
        {
            Carro carro = cdao.Buscar(codigo);
            cdao.Remover(carro);

            IList<Carro> carros = cdao.Listar();
            ViewBag.Carros = carros;
            return View("Index");
        }
    }
}