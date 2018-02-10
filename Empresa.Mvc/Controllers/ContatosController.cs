using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Repositorios.SqlServer;
using Empresa.Dominio;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : Controller
    {
        private EmpresaDbContext _db;// = new EmpresaDbContext();
        private IDataProtector _protectionProvider;

        public ContatosController(EmpresaDbContext db, IDataProtectionProvider protectionProvider, IConfiguration configuracao)
        {
            this._db = db;
            this._protectionProvider = protectionProvider.CreateProtector(configuracao.GetSection("ChaveCriptografia").Value);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(_db.Contatos.OrderBy(c => c.Nome).ToList());
        }

        [Authorize(Roles = "Admin, Corretor")]
        public  IActionResult Create()
        {

            return View();
        }

        [Authorize(Roles = "Admin, Corretor")]
        [HttpPost]
        public IActionResult Create(Contato contato)
        {

            //foreach (var clain in User.Claims)
            //{

            //}

            //var podeCriar = User.HasClaim("Contato", "Criar");

            //if (!podeCriar)
            //{
            //    return RedirectToAction("AcessoNegado", "Login");
            //}


            contato.Senha = _protectionProvider.Protect(contato.Senha);

            _db.Contatos.Add(contato);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
