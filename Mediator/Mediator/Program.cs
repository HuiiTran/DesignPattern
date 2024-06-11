namespace MediatorDesignPattern
{
    //Mediator Interface
    //This is going to be an Interface that defines operations 
    //which can be called by colleague objects for communication.
    public interface IFacebookGroupMediator
    {
        //This Method is used to send the Message who are registered with the Facebook Group
        void SendMessage(string msg, User user);
        //This method is used to register a user with the Facebook Group
        void RegisterUser(User user);
    }


    public class ConcreteFacebookGroupMediator : IFacebookGroupMediator
    {
        //The following variable is going to hold the list of objects to whom we want to communicate
        private List<User> UsersList = new List<User>();
        //The following method simply registers the user with Mediator
        public void RegisterUser(User user)
        {
            //Adding the user
            UsersList.Add(user);
            //Registering the user with Mediator
            user.Mediator = this;
        }
        public void SendMessage(string message, User user)
        {
            foreach (User u in UsersList)
            {
                //Message should not be received by the user sending it
                if (u != user)
                {
                    u.Receive(message);
                }
            }
        }
    }



    // This is going to be an abstract class that defines a property that holds a reference to a mediator.    
    public abstract class User
    {
        //This Property holds the name of the user
        protected string Name;
        //This Property is going to set and get the Mediator Instance
        //This Property value is going to be set when we register a user with the Mediator
        public IFacebookGroupMediator Mediator { get; set; }

        //Initializing the name using Constructor
        public User(string name)
        {
            this.Name = name;
        }
        //The following Methods are going to be Implemented by the Concrete Colleague
        public abstract void Send(string message);
        public abstract void Receive(string message);
    }




    //These are the classes that communicate with each other via the mediator.
    public class ConcreteUser : User
    {
        //Parameterized Constructor is required to set the base class Name Property
        public ConcreteUser(string Name) : base(Name)
        {
        }
        //Overriding the Receive Method
        //This method is going to use by the Mediator to send the message to each member of the group
        public override void Receive(string message)
        {
            Console.WriteLine(this.Name + ": Received Message:" + message);
        }
        //This method is used to send the message to the Mediator by a user
        public override void Send(string message)
        {
            Console.WriteLine(this.Name + ": Sending Message=" + message + "\n");
            Mediator.SendMessage(message, this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Create an Instance of Mediator i.e. Creating a Facebook Group
            IFacebookGroupMediator facebookMediator = new ConcreteFacebookGroupMediator();
            //Create instances of Colleague i.e. Creating users
            User Huy = new ConcreteUser("Huy");
            User Thien = new ConcreteUser("Thien");
            User Smith = new ConcreteUser("Smith");
            


            //Registering the users with the Mediator i.e. Facebook Group
            facebookMediator.RegisterUser(Huy);
            facebookMediator.RegisterUser(Thien);
            facebookMediator.RegisterUser(Smith);

            //One of the users Sending one Message in the Facebook Group
            Huy.Send("This is mediator design pattern");
            Console.WriteLine();
            //Another user Sending another Message in the Facebook Group
            Thien.Send("Cool! Please explain it ");
            Console.Read();
        }
    }
}

