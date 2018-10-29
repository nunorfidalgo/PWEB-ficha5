using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calculadora;
using ex2.Models;

namespace ex2.Controllers
{
    public class CalcularController : Controller
    {
        // GET: Calcular
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculadoraViewModel calculadora, string Operacao)
        {
            calculadora.Resultado = CalculadoraSimples.Calcular(calculadora.OperandoEsq, GetOperacao(Operacao), calculadora.OperandoDir);
            return View(calculadora);
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

    }
}