using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanTest.Model.Repository.TaxaJuros
{
    public class TaxaDeJurosRepository : ITaxaDeJurosRepository
    {
        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        public decimal RetornaTaxaDeJuros()
        {
            return 0.01m;
        }
    }
}
