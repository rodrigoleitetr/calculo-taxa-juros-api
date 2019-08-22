using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoftPlanTest.Lib.Services.TaxaDeJuros;
using SoftPlanTest.Model.API.TaxaJuros;

namespace SoftPlanTest.TaxaDeJurosCalculoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        /// <summary>
        /// O serviço de taxa de juros
        /// </summary>
        private ITaxaDeJurosService _taxaDeJurosService;

        public CalculaJurosController(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }

        /// <summary>
        /// Calcula os juros
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] CalculoTaxaDeJurosRequest model)
        {
            if (model == null) return BadRequest("É necessário informar um modelo válido.");

            if (ModelState.IsValid)
            {
                return Ok(await _taxaDeJurosService.CalculaTaxaDeJuros(model));
            }
            else
            {
                return BadRequest(model);
            }            
        }
    }
}