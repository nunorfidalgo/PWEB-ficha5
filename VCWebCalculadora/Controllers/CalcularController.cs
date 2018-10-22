using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VCWebCalculadora.Models;

namespace VCWebCalculadora.Controllers
{
    public class CalcularController : Controller
    {
        // GET: Calcular
        public ActionResult Index()
        {
            ViewBag.ListaNumDigDec = CalculadoraSimples.SelectListItems_DigitosDecimais();
            return View();
        }

        [HttpPost]
        //public ActionResult Index(string OperandoEsq, string TipoOp, string OperandoDir, int NumDigDec)
        //{
        //    ViewBag.Resultado = CalculadoraSimples.Calcular(OperandoEsq, SelectOperador(TipoOp), OperandoDir, NumDigDec);
        //    ViewBag.OperandoEsq = OperandoEsq;
        //    ViewBag.OperandoDir = OperandoDir;
        //    return View();
        //}

        public ActionResult Index(CalculadoraSimples modelo, string TipoOp)
        {
            modelo.Op = CalculadoraSimples.SelectOperador(TipoOp);
            ViewBag.ListaNumDigDec = CalculadoraSimples.SelectListItems_DigitosDecimais();
            ViewBag.Resultado = CalculadoraSimples.Calcular(modelo.OperandoEsq, modelo.Op, modelo.OperandoDir, modelo.NumDigDec);

            return View(modelo);
        }

        //[NonAction]
        //private Operacao SelectOperador(string op)
        //{
        //    Operacao tipoop = Operacao.adicao;
        //    switch (op)
        //    {
        //        case "Subtração":
        //            tipoop = Operacao.subtracao;
        //            break;
        //        case "Multiplicação":
        //            tipoop = Operacao.multiplicacao;
        //            break;
        //        case "Adição":
        //            tipoop = Operacao.adicao;
        //            break;
        //        case "Divisão":
        //            tipoop = Operacao.divisao;
        //            break;
        //    }
        //    return tipoop;
        //}
    }
}