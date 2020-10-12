using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factory
{
    public static class FactoryDemo
    {
        public static void main()
        {
            // 南昌工厂制作南昌的鸭脖和鸭架
            AbstractFactory nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYaBo();
            nanChangYabo.Print();

            // 上海工厂制作上海的鸭脖和鸭架
            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();

            Console.Read();
        }
    }

    /// <summary>
    /// 抽象工厂类，提供创建两个不同地方的鸭架和鸭脖的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了绝味中鸭脖和鸭架的创建接口
        public abstract YaBo CreateYaBo();
    }

    /// <summary>
    /// 南昌绝味工厂负责制作南昌的鸭脖和鸭架
    /// </summary>
    public class NanChangFactory : AbstractFactory
    {
        // 制作南昌鸭脖
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }
    }

    /// <summary>
    /// 上海绝味工厂负责制作上海的鸭脖和鸭架
    /// </summary>
    public class ShangHaiFactory : AbstractFactory
    {
        // 制作上海鸭脖
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
    }

    /// <summary>
    /// 鸭脖抽象类，供每个地方的鸭脖类继承
    /// </summary>
    public abstract class YaBo
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 南昌的鸭脖类，因为江西人喜欢吃辣的，所以南昌的鸭脖稍微会比上海做的辣
    /// </summary>
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    /// <summary>
    /// 上海的鸭脖没有南昌的鸭脖做的辣
    /// </summary>
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭脖");
        }
    }
}
