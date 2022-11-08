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
    public class CadastrarController : Controller
    {
        private readonly ILogger<CadastrarController> _logger;
        private readonly UsuarioService _usuarioService;

        public CadastrarController(ILogger<CadastrarController> logger, UsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [ActionName("Cadastrar")]
        [HttpPost]
        public async Task<IActionResult> Cadastrar(Usuario model)
        {
            _ = _usuarioService.CreateAsync(model);
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
