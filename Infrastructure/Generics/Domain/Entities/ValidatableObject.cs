using Generics.Domain.Exceptions;
using Generics.Infra.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Entities
{
    public class ValidatableObject
    {
        #region [ Propriedades ]

        private readonly DomainSummaryException _domainSummaryException = new DomainSummaryException();

        #endregion

        #region [ Métodos ]

        public virtual void AddException(ExceptionItemInfo exceptionItemInfo)
        {
            Throw.IfIsNull(exceptionItemInfo, nameof(exceptionItemInfo));
            this._domainSummaryException.Add(exceptionItemInfo);
        }
        public virtual void AddException(string model, string reference, string message, params object[] arguments)
        {
            var exceptionItemInfo = new ExceptionItemInfo(model, reference, message, arguments);
            this.AddException(exceptionItemInfo);
        }
        public virtual void Validate()
        {
            if (this.IsValid()) return;
            throw this._domainSummaryException;
        }
        public virtual bool IsValid() => _domainSummaryException.Exceptions == null || _domainSummaryException.Exceptions.Count == 0;

        #endregion
    }
}
