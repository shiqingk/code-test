using IOCAutofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCAutofac.IServices
{
    public interface ITestServices : IBaseServices<User>
    {
        public int sum(int a, int b);
    }
}
