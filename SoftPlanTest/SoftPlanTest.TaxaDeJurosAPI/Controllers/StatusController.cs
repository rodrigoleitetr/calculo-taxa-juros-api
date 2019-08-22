using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoftPlanTest.TaxaDeJurosAPI.Controllers
{
    [Route("/")]
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        /// <summary>
        /// Retorna o status do serviço
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Ok("Serviço de Taxa de Juros online.");
        }
    }
}