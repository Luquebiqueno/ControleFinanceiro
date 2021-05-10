using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Interfaces
{
    public interface IUnitOfWork<TContext>
    {
        int Commit();
    }
}
