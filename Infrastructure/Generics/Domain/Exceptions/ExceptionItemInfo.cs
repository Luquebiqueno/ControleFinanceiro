using Generics.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Exceptions
{
    public class ExceptionItemInfo
    {
        #region [ Propriedades ]

        public string Model { get; protected set; }
        public string Reference { get; protected set; }
        public string Message { get; protected set; }
        public object[] Arguments { get; protected set; }

        #endregion

        #region [ Construtores ]

        public ExceptionItemInfo(string model, string reference, string message, params object[] arguments)
        {
            Throw.IfIsNullOrWhiteSpace(model);
            Throw.IfIsNullOrWhiteSpace(reference);
            Throw.IfIsNullOrWhiteSpace(message);

            this.Model = model;
            this.Reference = reference;
            this.Message = message;
            this.Arguments = arguments;
        }

        #endregion
    }
}
