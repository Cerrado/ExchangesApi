using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExchangeApi.Models;
using ExchangeApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExchangeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangesController : ControllerBase
    {
        private readonly ILogger<ExchangesController> _logger;
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangesController(ILogger<ExchangesController> logger, IExchangeRepository exchangeRepository)
        {
            _exchangeRepository = exchangeRepository;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exchange>> GetExchange(int id)
        {
            var exchange = await _exchangeRepository.Get(id);
            if(exchange == null){
                return NotFound();
            }
            return Ok(exchange);
        }
    }
}