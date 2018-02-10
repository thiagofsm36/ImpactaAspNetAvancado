using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa.Mvc.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}
