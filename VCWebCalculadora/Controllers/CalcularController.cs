using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCWebCalculadora.Controllers
{
    public class CalcularController : Controller
    {
        // GET: Calcular
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string OperandoEsq, string TipoOp, string OperandoDir)
        {
            ViewBag.Resultado = CalculadoraSimples.Calcular(OperandoEsq, SelectOperador(TipoOp), OperandoDir);
            ViewBag.OperandoEsq = OperandoEsq;
            ViewBag.OperandoDir = OperandoDir;
            return View();
        }

        [NonAction]
        private Operacao SelectOperador(string op)
        {
            Operacao tipoop = Operacao.adicao;
            switch (op)
            {
                case "Subtração":
                    tipoop = Operacao.subtracao;
                    break;
                case "Multiplicação":
                    tipoop = Operacao.multiplicacao;
                    break;
                case "Adição":
                    tipoop = Operacao.adicao;
                    break;
                case "Divisão":
                    tipoop = Operacao.divisao;
                    break;
            }
            return tipoop;
        }
    }
}