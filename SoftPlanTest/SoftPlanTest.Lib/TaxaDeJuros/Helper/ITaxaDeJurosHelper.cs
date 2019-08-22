using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanTest.Lib.TaxaDeJuros.Helper
{
    public interface ITaxaDeJurosHelper
    {
        /// <summary>
        /// Executa um request a uma api "externa" (para efeito do teste) e retorna o valor
        /// </summary>
        /// <returns></returns>
        Task<decimal> GetTaxaDeJuros();
    }
}
