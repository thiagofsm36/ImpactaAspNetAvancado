using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Mvc.Models;

namespace Loja.Mvc.Filters.Tests
{
    [TestClass()]
    public class AuthorizeRoleTests
    {
        [TestMethod()]
        public void AuthorizeRoleTest()
        {
            var authorizeRole = new AuthorizeRole(Perfil.Administrador, Perfil.Comprador);

            Assert.IsTrue(authorizeRole.Roles.Contains("Administrador"));
            Assert.IsTrue(authorizeRole.Roles.Contains("Comprador"));

            //Assert.AreEqual(authorizeRole._roles.ToString(), "Administrador,Comprador,");
        }
    }
}