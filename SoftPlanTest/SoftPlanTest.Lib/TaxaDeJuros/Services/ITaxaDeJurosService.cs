using SoftPlanTest.Model.API.TaxaJuros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanTest.Lib.Services.TaxaDeJuros
{
    public interface ITaxaDeJurosService
    {
        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        TaxaJurosResponse GetTaxaJuros();

        /// <summary>
        /// Calcula a taxa de juros
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CalculoTaxaDeJurosResponse> CalculaTaxaDeJuros(CalculoTaxaDeJurosRequest model);
    }
}
