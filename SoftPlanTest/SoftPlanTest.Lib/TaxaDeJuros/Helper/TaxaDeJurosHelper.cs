using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SoftPlanTest.Model.API.TaxaJuros;
using SoftPlanTest.Model.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanTest.Lib.TaxaDeJuros.Helper
{
    public class TaxaDeJurosHelper : ITaxaDeJurosHelper
    {
        /// <summary>
        /// Configurações da API de calculo da taxa de juros
        /// </summary>
        private readonly CalculoTaxaDeJurosApiGeneralConfig _calculoTaxaDeJurosApiConfig;

        public TaxaDeJurosHelper(IOptions<CalculoTaxaDeJurosApiGeneralConfig> calculoTaxaDeJurosConfig)
        {
            _calculoTaxaDeJurosApiConfig = calculoTaxaDeJurosConfig?.Value ?? throw new Exception("Não foi possível obter as configurações da API de calculo de taxa de juros.");
        }

        /// <summary>
        /// Executa um request a uma api "externa" (para efeito do teste) e retorna o valor
        /// </summary>
        /// <returns></returns>
        public async Task<decimal> GetTaxaDeJuros()
        {
            if (string.IsNullOrEmpty(_calculoTaxaDeJurosApiConfig.TaxaDeJurosServiceUrl))
                throw new InvalidOperationException(string.Format("A configuração {0} não pode estar vazia no arquivo de configurações.", nameof(_calculoTaxaDeJurosApiConfig.TaxaDeJurosServiceUrl)));

            using (var request = new HttpClient())
            {
                var apiResponse = await request.GetAsync(_calculoTaxaDeJurosApiConfig.TaxaDeJurosServiceUrl);

                if (!apiResponse.IsSuccessStatusCode)
                    throw new InvalidOperationException(string.Format("Não foi possível obter a taxa de juros da API, retorno: {0}.", await apiResponse.Content.ReadAsStringAsync()));

                var result = JsonConvert.DeserializeObject<TaxaJurosResponse>(await apiResponse.Content.ReadAsStringAsync());

                return result.ValorTaxaJuros;
            }
        }
    }
}
