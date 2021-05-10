using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Interfaces
{
    public interface IViewModel<out TEntity>
    {
        TEntity Model();
    }
}
