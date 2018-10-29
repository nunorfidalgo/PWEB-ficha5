using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculadora;
using WebApp3Calculadora.Models;

namespace WebApp3Calculadora.Controllers
{
    public class CalcularController : Controller
    {
        CalculadoraViewModel model = new CalculadoraViewModel();

        // GET: Calcular
        [HttpGet]
        public ActionResult Index()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(CalculadoraViewModel model, string Operacao)
        {
            ModelState.Clear();
            model.Resultado = CalculadoraSimples.Calcular(model.OperandoEsq, GetOperacao(Operacao), model.OperandoDir, model.NDigitosDec);
            return View(model);
        }

        private CalculadoraSimples.TipoOperador GetOperacao(string op)
        {
            CalculadoraSimples.TipoOperador operacao = CalculadoraSimples.TipoOperador.divisao;
            switch (op)
            {
                case "Subtração":
                    operacao = CalculadoraSimples.TipoOperador.subtracao;
                    break;
                case "Multiplicação":
                    operacao = CalculadoraSimples.TipoOperador.multiplicacao;
                    break;
                case "Adição":
                    operacao = CalculadoraSimples.TipoOperador.adicao;
                    break;
                case "Divisão":
                    operacao = CalculadoraSimples.TipoOperador.divisao;
                    break;
            }
            return operacao;
        }

        static public SelectList ListaDigitosDecimais(int ndd = 6)
        {
            List<SelectListItem> ListaNumDig = new List<SelectListItem>();
            for (int p = 0; p <= ndd; p++)
            {
                ListaNumDig.Add(new SelectListItem { Text = "Digitos Decimais[" + p.ToString() + "]", Value = p.ToString() });

            }
            return new SelectList(ListaNumDig, "Value", "Text");
        }

    }
}