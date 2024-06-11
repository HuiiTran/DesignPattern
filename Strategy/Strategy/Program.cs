using System;
using System.Collections.Generic;
namespace Strategy
{
    // The Context defines the interface of interest to clients.
    class Context
    {
        
        private IStrategy _strategy;

        public Context()
        { }

        
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }

      
        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

       
        public void DoSomeBusinessLogic()
        {
            Console.WriteLine("Context: Sorting data using the strategy ");
            var result = this._strategy.DoAlgorithm(new List<string> {"c", "d", "a",  "b", "e" });

            string resultStr = string.Empty;
            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    
    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

   
    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;
            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}