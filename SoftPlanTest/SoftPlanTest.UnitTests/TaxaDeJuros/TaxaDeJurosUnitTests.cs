using Microsoft.Extensions.Options;
using Moq;
using SoftPlanTest.Lib.Services.TaxaDeJuros;
using SoftPlanTest.Lib.TaxaDeJuros.Helper;
using SoftPlanTest.Model.Config;
using SoftPlanTest.Model.Repository.TaxaJuros;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SoftPlanTest.UnitTests.TaxaDeJuros
{
    public class TaxaDeJurosUnitTests
    {
        /// <summary>
        /// Valida se o código está retornando o valor padrão da taxa de juros
        /// </summary>
        [Fact]
        public void TestaValorPadraoTaxaDeJuros()
        {
            var defaultValue = 0.01m;
            var taxaDeJurosRepository = new TaxaDeJurosRepository();
            
            var taxaDeJuros = taxaDeJurosRepository.RetornaTaxaDeJuros();

            Assert.Equal(defaultValue, taxaDeJuros);
        }

        /// <summary>
        /// Valida se o cálculo da taxa de juros está OK
        /// </summary>
        [Fact]
        public void TestaCalculoTaxaDeJurosValorPadrao()
        {
            var defaultValue = "105.10";
            var taxaDeJurosRepositoryMock = new Mock<ITaxaDeJurosRepository>();
            var taxaDeJurosHelperMOck = new Mock<ITaxaDeJurosHelper>();

            taxaDeJurosHelperMOck.Setup(x => x.GetTaxaDeJuros()).Returns(Task.FromResult(0.01m));

            var taxaDeJurosService = new TaxaDeJurosService(taxaDeJurosHelperMOck.Object, taxaDeJurosRepositoryMock.Object);

            var result = taxaDeJurosService.CalculaTaxaDeJuros(new Model.API.TaxaJuros.CalculoTaxaDeJurosRequest()
            {
                Meses = 5,
                ValorInicial = 100
            }).Result;

            Assert.Equal(defaultValue, result.ValorCalculado);
        }
    }
}
