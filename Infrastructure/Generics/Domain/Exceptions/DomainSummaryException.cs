using Generics.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Exceptions
{
    public class DomainSummaryException : Exception
    {
        #region [ Propriedades ]
        public List<ExceptionItemInfo> Exceptions { get; set; } = new List<ExceptionItemInfo>();

        #endregion

        #region [ Construtores ]

        public DomainSummaryException() { }

        public DomainSummaryException(List<ExceptionItemInfo> exceptions) => this.Exceptions.AddRange(exceptions);

        #endregion

        #region [ Métodos ]

        public void Add(ExceptionItemInfo exceptionItemInfo)
        {
            Throw.IfIsNull(exceptionItemInfo, nameof(exceptionItemInfo));
            this.Exceptions.Add(exceptionItemInfo);
        }

        public void Add(string model, string reference, string message)
        {
            var exceptionItemInfo = new ExceptionItemInfo(model, reference, message);
            this.Add(exceptionItemInfo);
        }

        #endregion
    }
}
