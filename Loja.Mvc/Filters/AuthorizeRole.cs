using Loja.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Filters
{
    public class AuthorizeRole : AuthorizeAttribute
    {

        //public string _roles { get; set; }

        public AuthorizeRole(params Perfil[] perfis)
        {
            foreach (var perfil in perfis)
            {
                Roles += perfil + ",";
            }

            //_roles = Roles;

            //Roles = string.Join(",", perfis.Select(p => Enum.GetName(p.GetType(), p)));
        }

    }
}