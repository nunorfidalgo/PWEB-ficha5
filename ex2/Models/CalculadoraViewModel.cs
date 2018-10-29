using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ex2.Models
{

    public class CalculadoraViewModel
    {
        public string OperandoEsq { get; set; }
        public string OperandoDir { get; set; }
        public string Resultado { get; set; }
    }
}