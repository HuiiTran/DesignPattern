using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        MonAnFactory loaiTron = new LoaiTronFactory();
        Client TronClient = new Client(loaiTron);

        MonAnFactory loaiBo = new LoaiBoFactory();
        Client BoClient = new Client(loaiBo);

        Console.WriteLine("********* Pho **********");
        Console.WriteLine(TronClient.GetPhoDetails());
        Console.WriteLine(BoClient.GetPhoDetails());

        Console.WriteLine("******* MY **********");
        Console.WriteLine(TronClient.GetMyDetails());
        Console.WriteLine(BoClient.GetMyDetails());

        Console.ReadKey();
    }
}
