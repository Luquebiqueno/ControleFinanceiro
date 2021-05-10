using ControleFinanceiro.Domain.Entities;
using Generics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.ViewModels
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long? Telefone { get; set; }
        public string Login { get; set; }

        public Usuario Model()
        {
            return new Usuario(Id, Nome, Email, Telefone, Login);
        }
    }
}
