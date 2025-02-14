﻿using System;
using System.Collections.Generic;
namespace Observer
{
    /// <summary>
    /// Observer Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create Apple stock and attach investors
            Apple Apple = new Apple("Apple", 120.00);
            Apple.Attach(new Investor("Huy"));
            Apple.Attach(new Investor("Thien"));
            // Fluctuating prices will notify investors
            Apple.Price = 120.10;
            Apple.Price = 121.00;
            Apple.Price = 120.50;
            Apple.Price = 120.75;
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    public abstract class Stock
    {
        private string symbol;
        private double price;
        private List<IInvestor> investors = new List<IInvestor>();
        // Constructor
        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }
        public void Attach(IInvestor investor)
        {
            investors.Add(investor);
        }
        public void Detach(IInvestor investor)
        {
            investors.Remove(investor);
        }
        public void Notify()
        {
            foreach (IInvestor investor in investors)
            {
                investor.Update(this);
            }
            Console.WriteLine("");
        }
        // Gets or sets the price
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    Notify();
                }
            }
        }
        // Gets the symbol
        public string Symbol
        {
            get { return symbol; }
        }
    }
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class Apple : Stock
    {
        // Constructor
        public Apple(string symbol, double price)
            : base(symbol, price)
        {
        }
    }
    /// <summary>
    /// The 'Observer' interface
    /// </summary>
    public interface IInvestor
    {
        void Update(Stock stock);
    }
    /// <summary>
    /// The 'ConcreteObserver' class
    /// </summary>
    public class Investor : IInvestor
    {
        private string name;
        private Stock stock;
        // Constructor
        public Investor(string name)
        {
            this.name = name;
        }
        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                "change to {2:C}", name, stock.Symbol, stock.Price);
        }
        // Gets or sets the stock
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}