using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Exceptions
{
    public class UsuarioExpiradoException : Exception
    {
        #region [ Propriedades ]

        public ExceptionItemInfo ExceptionItemInfo { get; set; }

        #endregion

        #region [ Propriedades ]

        public UsuarioExpiradoException(string model, string reference, string message) : this(new ExceptionItemInfo(model, reference, message))
        {

        }
        public UsuarioExpiradoException(ExceptionItemInfo exceptionItemInfo) : base(exceptionItemInfo.Message) => this.ExceptionItemInfo = exceptionItemInfo;

        #endregion
    }
}
