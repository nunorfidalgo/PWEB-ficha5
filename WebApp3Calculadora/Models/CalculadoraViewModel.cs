using WebApp3Calculadora.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp3Calculadora.Models
{

    public class CalculadoraViewModel
    {
        [Required]
        [Display(Name = "1º Operando")]
        public string OperandoEsq { get; set; }
        [Required]
        [Display(Name = "2º Operando")]
        public string OperandoDir { get; set; }

        [Display(Name = "Resultado")]
        public string Resultado { get; set; }

        [Display(Name = "Nº de Digitos")]
        public SelectList DDLDigitosDec { get; set; }

        public int NDigitosDec { get; set; }

        public CalculadoraViewModel()
        {
            DDLDigitosDec = CalcularController.ListaDigitosDecimais();
        }
    }
}