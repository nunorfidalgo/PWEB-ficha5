using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VCWebCalculadora.Controllers
{
    public enum Operacao { adicao, subtracao, multiplicacao, divisao }

    public class CalculadoraSimples
    {
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
    }
}