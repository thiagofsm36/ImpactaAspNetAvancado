using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Empresa.Mvc.ViewModels;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Empresa.Mvc.Controllers
{
    public class LoginController : Controller
    {

        private EmpresaDbContext _db;// = new EmpresaDbContext();
        private IDataProtector _protectionProvider;

        public LoginController(EmpresaDbContext db, IDataProtectionProvider protectionProvider, IConfiguration configuracao)
        {
            this._db = db;
            this._protectionProvider = protectionProvider.CreateProtector(configuracao.GetSection("ChaveCriptografia").Value);
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel login)
        {



            var contato = _db.Contatos.Where(c => c.Email == login.Email && _protectionProvider.Unprotect(c.Senha) == login.Senha)
                                      .SingleOrDefault();

            if (contato == null)
            {
                ModelState.AddModelError("", "Usuário/Senha incorretos.");
                return View(login);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
