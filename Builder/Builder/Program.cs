using System;
using System.Collections.Generic;

namespace Huy 
{

    public interface IBuilder
    {
        void AddPizzaBase();

        void AddCheese();

        void AddVegetable();

        void AddSausage();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Pizza _pizza = new Pizza();


        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._pizza = new Pizza();
        }

        public void AddPizzaBase()
        {
            this._pizza.Add("PizzaBase");
        }

        public void AddCheese()
        {
            this._pizza.Add("Cheese");
        }

        public void AddVegetable()
        {
            this._pizza.Add("Vegetable");
        }
        
        public void AddSausage()
        {
            this._pizza.Add("Sausage");
        }

       
        public Pizza GetPizza()
        {
            Pizza result = this._pizza;

            this.Reset();

            return result;
        }
    }

     
    public class Pizza
    {
        private List<object> _component = new List<object>();

        public void Add(string component)
        {
            this._component.Add(component);
        }

        public string Listcomponent()
        {
            string str = string.Empty;

            for (int i = 0; i < this._component.Count; i++)
            {
                str += this._component[i] + ", ";
            }

            str = str.Remove(str.Length - 2);

            return "Pizza component: " + str + "\n";
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        public void BanhChay()
        {
            this._builder.AddPizzaBase();
            this._builder.AddVegetable();
        }
        public void BuildMinimalViablePizza()
        {
            this._builder.AddPizzaBase();
        }

        public void BuildFullFeaturedPizza()
        {
            this._builder.AddPizzaBase();
            this._builder.AddCheese();
            this._builder.AddVegetable();
            this._builder.AddSausage();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();

            var builder = new ConcreteBuilder();

            director.Builder = builder;

            Console.WriteLine("Just pizza base:");
            director.BuildMinimalViablePizza();
            Console.WriteLine(builder.GetPizza().Listcomponent());

            Console.WriteLine("Standard full component pizza:");
            director.BuildFullFeaturedPizza();
            Console.WriteLine(builder.GetPizza().Listcomponent());


            director.BanhChay();
            Console.WriteLine(builder.GetPizza().Listcomponent());

            /*Console.WriteLine("Custom pizza:");
            builder.AddPizzaBase();
            builder.AddSausage();
            Console.Write(builder.GetPizza().Listcomponent());*/
        }
    }
}