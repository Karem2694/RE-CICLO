using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecicloPortal.Models;
using RecicloPortal.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RecicloPortal.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;
        private readonly AgendamentoService _agendamentoService;

        public AgendamentoController(ILogger<AgendamentoController> logger, AgendamentoService agendamentoService)
        {
            _logger = logger;
            _agendamentoService = agendamentoService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ActionName("Agendar")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Agendamento model)
        {
            _ = _agendamentoService.CreateAsync(model);
            return View("Sucesso");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
