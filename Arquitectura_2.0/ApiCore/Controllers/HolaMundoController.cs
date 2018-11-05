using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo;
using Contexto;
using RepositorioCore;
using Microsoft.Extensions.Logging;

namespace ApiCore.Controllers
{
    [Route("api/monedas")]
    public class HolaMundoController : ControllerBase
    {
        private ILogger<HolaMundoController> _logger;
        private readonly IRepositorio _repositorio;
        public HolaMundoController(IRepositorio repositorio, ILogger<HolaMundoController> logger)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        [HttpGet()]
        public IActionResult HolaPepe()
        {
            var monedas = _repositorio.GetMonedas();
            //devuelve todos los valores
            _logger.LogInformation("Mostradas todas las monedas" + monedas);
            return Ok( monedas );
        }

        [HttpPost()]
        public IActionResult SetMoneda([FromBody] Moneda moneda)
        {
            _repositorio.ActualizarMoneda(moneda);
            return Ok(moneda);
        }

        [HttpPut()]
        public IActionResult PutMoneda([FromBody] Moneda moneda)
        {
            _repositorio.CrearMoneda(moneda);
            return Ok(moneda);
        }

        [HttpDelete()]
        public IActionResult DeleteMoneda([FromBody] string id)
        {
            int idInt = 0;
            Int32.TryParse(id, out idInt);
            _repositorio.BorrarMoneda(idInt);
            return Ok(idInt);
        }
    }
}
