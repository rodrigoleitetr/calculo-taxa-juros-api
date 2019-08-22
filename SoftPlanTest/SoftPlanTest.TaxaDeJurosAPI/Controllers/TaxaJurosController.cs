using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftPlanTest.Lib.Services.TaxaDeJuros;

namespace SoftPlanTest.TaxaDeJurosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// O serviço de taxa de juros
        /// </summary>
        private readonly ITaxaDeJurosService _taxaJurosService;

        public TaxaJurosController(ITaxaDeJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        /// <summary>
        /// Retorna a taxa de juros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_taxaJurosService.GetTaxaJuros());
        }
    }
}
