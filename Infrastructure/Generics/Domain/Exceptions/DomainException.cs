using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Exceptions
{
    public class DomainException : Exception
    {
        #region [ Propriedades ]

        public ExceptionItemInfo ExceptionItemInfo { get; set; }

        #endregion

        #region [ Construtores ]

        public DomainException(string model, string reference, string message, params object[] arguments) : this(new ExceptionItemInfo(model, reference, message, arguments))
        {

        }
        public DomainException(ExceptionItemInfo exceptionItemInfo) : base(exceptionItemInfo.Message) => this.ExceptionItemInfo = exceptionItemInfo;

        #endregion
    }
}
