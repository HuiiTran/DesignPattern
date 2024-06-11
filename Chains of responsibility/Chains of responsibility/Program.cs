using System;

// Handler interface
public interface ISupportHandler
{
    void SetNextHandler(ISupportHandler handler);
    void HandleTicket(Ticket ticket);
}

// Abstract base class for concrete handlers
public abstract class SupportHandlerBase : ISupportHandler
{
    private ISupportHandler _nextHandler;

    public void SetNextHandler(ISupportHandler handler)
    {
        _nextHandler = handler;
    }

    public virtual void HandleTicket(Ticket ticket)
    {
        // If this handler can handle the ticket, do the handling
        if (CanHandleTicket(ticket))
        {
            Handle(ticket);
        }
        // If there is a next handler, pass the ticket to it
        else if (_nextHandler != null)
        {
            _nextHandler.HandleTicket(ticket);
        }
        // No handler in the chain can handle the ticket
        else
        {
            Console.WriteLine("Ticket cannot be handled.");
        }
    }

    protected abstract bool CanHandleTicket(Ticket ticket);
    protected abstract void Handle(Ticket ticket);
}

// Concrete handler: Level 1 Support
public class Level1SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.Low;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 1 Support handles the ticket.");
        // Handle the ticket at Level 1 Support
    }
}

// Concrete handler: Level 2 Support
public class Level2SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.Medium;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 2 Support handles the ticket.");
        // Handle the ticket at Level 2 Support
    }
}

// Concrete handler: Level 3 Support
public class Level3SupportHandler : SupportHandlerBase
{
    protected override bool CanHandleTicket(Ticket ticket)
    {
        return ticket.Severity == Severity.High;
    }

    protected override void Handle(Ticket ticket)
    {
        Console.WriteLine("Level 3 Support handles the ticket.");
        // Handle the ticket at Level 3 Support
    }
}

// Ticket class
public class Ticket
{
    public Severity Severity { get; set; }
    // Other ticket properties
}

// Enum representing severity levels of tickets
public enum Severity
{
    Low, 
    Medium,
    High,
    Ultra,
}

// Usage example
public class Program
{
    public static void Main()
    {
        // Create the support handlers
        var level3SupportHandler = new Level3SupportHandler();
        var level2SupportHandler = new Level2SupportHandler();
        var level1SupportHandler = new Level1SupportHandler();

        // Set the chain of responsibility
        level1SupportHandler.SetNextHandler(level2SupportHandler);
        level2SupportHandler.SetNextHandler(level3SupportHandler);

        // Create tickets
        var ticket1 = new Ticket { Severity = Severity.Low };
        var ticket2 = new Ticket { Severity = Severity.Medium };
        var ticket3 = new Ticket { Severity = Severity.High };
        var ticket4 = new Ticket { Severity = Severity.Ultra };

        // Process the tickets
        level1SupportHandler.HandleTicket(ticket1);
        level1SupportHandler.HandleTicket(ticket2);
        level1SupportHandler.HandleTicket(ticket3);
        level1SupportHandler.HandleTicket(ticket4);
    }
}












































/*

using System;
namespace Chain.RealWorld
{
    /// <summary>
    /// Chain of Responsibility Design Pattern
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();
            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);
            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Supplies");
            larry.ProcessRequest(p);
            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);
            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class Approver
    {
        protected Approver successor;
        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
        public abstract void ProcessRequest(Purchase purchase);
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }
    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }
    /// <summary>
    /// Class holding request details
    /// </summary>
    public class Purchase
    {
        int number;
        double amount;
        string purpose;
        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this.number = number;
            this.amount = amount;
            this.purpose = purpose;
        }
        // Gets or sets purchase number
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        // Gets or sets purchase amount
        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        // Gets or sets purchase purpose
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }
    }
}*/