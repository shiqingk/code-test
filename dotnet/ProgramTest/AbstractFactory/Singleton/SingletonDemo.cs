using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractFactory.Singleton
{
    public class SingletonDemo
    {
        private static SingletonDemo _demo;
        private static readonly object obj = new object();
        public static SingletonDemo Instance
        {
            get
            {
                if (_demo == null)
                {
                    lock (obj)
                    {
                        if (_demo == null)
                        {
                            _demo = new SingletonDemo();
                        }

                        return _demo;
                    }
                }

                return _demo;
            }
        }
    }
}
