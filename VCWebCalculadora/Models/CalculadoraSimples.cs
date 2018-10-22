using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCWebCalculadora.Models
{
    public enum Operacao { adicao, subtracao, multiplicacao, divisao }

    public class CalculadoraSimples
    {
        public string OperandoEsq { get; set; }
        public string OperandoDir { get; set; }
        public Operacao Op { get; set; }
        public int NumDigDec { get; set; }

        public CalculadoraSimples() { }

        public static string Calcular(string OpEsq, Operacao Op, string OpDir, int NumDigDec = 2)
        {
            double v1 = 0, v2 = 0;
            string resultado = String.Empty;
            string ndd = "F" + NumDigDec.ToString();

            if (double.TryParse(OpEsq, out v1) && double.TryParse(OpDir, out v2))
            {
                switch (Op)
                {
                    case Operacao.adicao:
                        resultado = (v1 + v2).ToString(ndd);
                        break;
                    case Operacao.subtracao:
                        resultado = (v1 - v2).ToString(ndd);
                        break;
                    case Operacao.multiplicacao:
                        resultado = (v1 * v2).ToString(ndd);
                        break;
                    case Operacao.divisao:
                        resultado = v2 != 0 ? (v1 / v2).ToString(ndd) : "Infinito";
                        break;
                }
            }
            else
            {
                resultado = "Incorrecto";
            }
            return resultado;
        }

        // private Operacao SelectOperador(string op)
        static public Operacao SelectOperador(string op)
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

        static public List<SelectListItem> SelectListItems_DigitosDecimais(int ndd = 6)
        {
            List<SelectListItem> ListaNumDig = new List<SelectListItem>();
            for (int p = 0; p <= ndd; p++)
            {
                ListaNumDig.Add(new SelectListItem { Text = "Digitos Decimais[" + p.ToString() + "]", Value = p.ToString() });

            }
            return ListaNumDig;
        }
    }
}