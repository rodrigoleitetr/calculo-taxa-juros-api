using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlanTest.Model.Repository.TaxaJuros
{
    public interface ITaxaDeJurosRepository
    {
        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        decimal RetornaTaxaDeJuros();
    }
}
