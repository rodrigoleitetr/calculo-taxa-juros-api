using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SoftPlanTest.Lib.TaxaDeJuros.Helper;
using SoftPlanTest.Model.API.TaxaJuros;
using SoftPlanTest.Model.Config;
using SoftPlanTest.Model.Repository.TaxaJuros;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanTest.Lib.Services.TaxaDeJuros
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        /// <summary>
        /// Repository de taxa de juros
        /// </summary>
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;

        /// <summary>
        /// The taxa de juros helper
        /// </summary>
        private readonly ITaxaDeJurosHelper _taxaDeJurosHelper;

        public TaxaDeJurosService(ITaxaDeJurosHelper taxaDeJurosHelper, ITaxaDeJurosRepository taxaDeJurosRepository)
        {
            _taxaDeJurosRepository = taxaDeJurosRepository;
            _taxaDeJurosHelper = taxaDeJurosHelper;
        }        

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        public TaxaJurosResponse GetTaxaJuros()
        {
            return new TaxaJurosResponse()
            {
                ValorTaxaJuros = _taxaDeJurosRepository.RetornaTaxaDeJuros()
            };
        }

        /// <summary>
        /// Calcula a taxa de juros
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<CalculoTaxaDeJurosResponse> CalculaTaxaDeJuros(CalculoTaxaDeJurosRequest model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            // Busca a taxa de juros
            var valorTaxaDeJuros = await _taxaDeJurosHelper.GetTaxaDeJuros();
            
            // Realiza o calculo da taxa de juros
            var resultadoCalculoTaxaDeJuros = ExecutaCalculoTaxaDeJuros(model.ValorInicial, model.Meses, valorTaxaDeJuros);

            return new CalculoTaxaDeJurosResponse()
            {
                ValorCalculado = string.Format("{0:0.00}", resultadoCalculoTaxaDeJuros)
            };
        }

        /// <summary>
        /// Realiza o calculo da taxa de juros
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="tempoEmMeses"></param>
        /// <param name="taxaDeJuros"></param>
        /// <returns></returns>
        private decimal ExecutaCalculoTaxaDeJuros(decimal valorInicial, int tempoEmMeses, decimal taxaDeJuros)
        {
            return valorInicial * (decimal)Math.Pow(Convert.ToDouble((1 + taxaDeJuros)), tempoEmMeses);
        }        
    }
}
