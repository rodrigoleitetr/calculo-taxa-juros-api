using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftPlanTest.Model.API.TaxaJuros
{
    public class CalculoTaxaDeJurosRequest
    {
        /// <summary>
        /// O valor inicial a ser calculado
        /// </summary>
        [Required]
        public int ValorInicial { get; set; }

        /// <summary>
        /// O número de meses a ser usado no cálculo
        /// </summary>
        [Required]
        public int Meses { get; set; }
    }
}
