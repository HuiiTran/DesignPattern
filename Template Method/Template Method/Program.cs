
using System;
using System.Collections.Generic;
namespace Template.RealWorld
{

    public class Program
    {
        public static void Main(string[] args)
        {
            DataAccessor categories = new Categories();
            categories.Run(5);
            DataAccessor products = new Products();
            products.Run(3);
            // Wait for user
            Console.ReadKey();
        }
    }

    /// The 'AbstractClass' abstract class

    public abstract class DataAccessor
    {
        public abstract void Connect();
        public abstract void Select();
        public abstract void Process(int top);
        public abstract void Disconnect();
        // The 'Template Method' 
        public void Run(int top)
        {
            Connect();
            Select();
            Process(top);
            Disconnect();
        }
    }

    /// A 'ConcreteClass' class

    public class Categories : DataAccessor
    {
        private List<string> categories;
        public override void Connect()
        {
            categories = new List<string>();
        }
        public override void Select()
        {
            categories.Add("Red");      //1
            categories.Add("Green");    //2
            categories.Add("Blue");     //3
            categories.Add("Yellow");   //4
            categories.Add("Purple");   //5
            categories.Add("White");    //6
            categories.Add("Black");    //7
        }
        public override void Process(int top)
        {
            Console.WriteLine("Categories ---- ");
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(categories[i]);
            }

            Console.WriteLine();
        }
        public override void Disconnect()
        {
            categories.Clear();
        }
    }

    /// A 'ConcreteClass' class

    public class Products : DataAccessor
    {
        private List<string> products;
        public override void Connect()
        {
            products = new List<string>();
        }
        public override void Select()
        {
            products.Add("Car");                        //1
            products.Add("Bike");                       //2
            products.Add("Boat");                       //3
            products.Add("Truck");                      //4
            products.Add("Moped");                      //5
            products.Add("Rollerskate");                //6
            products.Add("Stroller");                   //7
        }
        public override void Process(int top)
        {
            Console.WriteLine("Products ---- ");
            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(products[i]);
            }
            Console.WriteLine();
        }
        public override void Disconnect()
        {
            products.Clear();
        }
    }
}




























































/*abstract class DataMiner
{
    string file;
    public string File { get => file; set => file = value; }

    string rawData;
    public string RawData { get => rawData; set => rawData = value; }

    public virtual void openFile(string path)
    {
        Console.WriteLine("Open " + path);
    }
    public virtual void closeFile()
    {
        Console.WriteLine("Close file\n");
    }
    public abstract void extractData();
    public abstract void parseData();

    public void mine(string path)
    {
        openFile(path);
        extractData();
        parseData();
        closeFile();
    }

}

class CSVDataMiner : DataMiner
{
    public override void extractData()
    {
        Console.WriteLine("Extract CSV");
    }

    public override void parseData()
    {
        Console.WriteLine("Parse CSV");
    }
}

class PDFDataMiner : DataMiner
{
    public override void openFile(string path)
    {
        base.openFile(path);
        this.File = "PDF";
    }
    public override void extractData()
    {
        Console.WriteLine("Extract " + this.File);
        this.RawData = "PDF";
    }

    public override void parseData()
    {
        Console.WriteLine("Parse " + this.RawData);
    }
}

class Program
{
    static void Main(string[] args)
    {
        PDFDataMiner pdfDataMiner = new PDFDataMiner();
        pdfDataMiner.mine("pdf path");

        CSVDataMiner csvDataMiner = new CSVDataMiner();
        csvDataMiner.mine("csv path");
    }

}*/