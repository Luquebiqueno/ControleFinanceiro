using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Accessor
{
    public class User : IUser
    {
        private readonly IHttpContextAccessor _accessor;
        public User(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string Name => _accessor.HttpContext.User.Identity.Name;
    }
}
