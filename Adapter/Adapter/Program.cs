using System;

namespace RefactoringGuru.DesignPatterns.Adapter.Conceptual
{
    public interface ITarget //client interface
    {
        string GetRequest();
    }

   
    class Services
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    class Adapter : ITarget
    {
        private readonly Services _service;

        public Adapter(Services service)
        {
            this._service = service;
        }

        public string GetRequest()
        {
            return $"This is '{this._service.GetSpecificRequest()}'";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Services service = new Services();
            ITarget target = new Adapter(service);

            

            Console.WriteLine(target.GetRequest());
        }
    }
}