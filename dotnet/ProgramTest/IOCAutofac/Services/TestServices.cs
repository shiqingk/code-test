using IOCAutofac.IServices;
using IOCAutofac.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCAutofac.Services
{
    public class TestServices : ITestServices
    {
        public User Find(string id)
        {
            throw new NotImplementedException();
        }

        public int sum(int a, int b)
        {
            return a + b;
        }
    }
}
