using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCAutofac.IServices
{
    public interface IBaseServices<T> where T : class, new()
    {
        T Find(string id);
    }
}
