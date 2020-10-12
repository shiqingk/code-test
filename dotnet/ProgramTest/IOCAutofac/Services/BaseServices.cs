using IOCAutofac.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCAutofac.Services
{
    public class BaseServices<T> : IBaseServices<T> where T: class, new()
    {
        public T Find(string id)
        {
            return null;
        }
    }
}
