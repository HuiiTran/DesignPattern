namespace VirtualProxyDesignPattern
{
    // The Subject interface declares common operations for both RealSubject and the Proxy. 
    // As long as the client works with RealSubject using this interface, 
    // you will be able to pass it a proxy instead of a real subject.
    public interface IImage
    {
        void DisplayImage();
    }






    // The RealSubject contains some core business logic. 
    // Usually, RealSubjects are capable of doing some useful work which may be very slow or sensitive 
    // A Proxy can solve these issues without any changes to the RealSubject's code.
    public class RealImage : IImage
    {
        private string Filename { get; set; }
        public RealImage(string filename)
        {
            Filename = filename;
            LoadImageFromDisk();
        }
        public void LoadImageFromDisk()
        {
            Console.WriteLine("Loading Image : " + Filename);
        }
        public void DisplayImage()
        {
            Console.WriteLine("Displaying Image : " + Filename);
        }
    }




    // The Proxy has an interface identical to the RealSubject.
    public class ProxyImage : IImage
    {
        private RealImage realImage = null;
        private string Filename { get; set; }
        public ProxyImage(string filename)
        {
            Filename = filename;
        }
        public void DisplayImage()
        {
            if (realImage == null)
            {
                realImage = new RealImage(Filename);
            }
            realImage.DisplayImage();
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            IImage Image1 = new ProxyImage("Tiger Image");

            Console.WriteLine("Image1 calling DisplayImage first time :");
            Image1.DisplayImage(); // loading necessary

            Console.WriteLine("Image1 calling DisplayImage second time :");
            Image1.DisplayImage(); // loading unnecessary

            Console.WriteLine("Image1 calling DisplayImage third time :");
            Image1.DisplayImage(); // loading unnecessary

            Console.WriteLine();
            IImage Image2 = new ProxyImage("Lion Image");

            Console.WriteLine("Image2 calling DisplayImage first time :");
            Image2.DisplayImage(); // loading necessary

            Console.WriteLine("Image2 calling DisplayImage second time :");
            Image2.DisplayImage(); // loading unnecessary

            Console.ReadKey();
        }
    }
}