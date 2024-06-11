//Element Interface
public interface IElement
{
    void Accept(IVisitor visitor);
}

//concrete elements
public class Kid : IElement
{
    public string KidName { get; set; }
    public Kid(string name)
    {
        KidName = name;
    }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}



// visitor interface 
public interface IVisitor
{
    void Visit(IElement element);
}


// concrete visitors
public class Doctor : IVisitor
{
    public string Name { get; set; }
    public Doctor(string name)
    {
        Name = name;
    }
    public void Visit(IElement element)
    {
        Kid kid = (Kid)element;
        Console.WriteLine($"Doctor: {Name} did the health checkup of the child: {kid.KidName}");
    }
}

class Nurse : IVisitor
{
    public string Name { get; set; }
    public Nurse(string name)
    {
        Name = name;
    }

    public void Visit(IElement element)
    {
        Kid kid = (Kid)element;
        Console.WriteLine($"The nurse: {Name} wrote down the result for: {kid.KidName}");
    }
}



//
public class School
{
    private static readonly List<IElement> Elements = new List<IElement>();
    static School()
    {
        Elements = new List<IElement>
            {
                new Kid("john"),
                new Kid("sara"),
                new Kid("pan")
            };
    }
    public void PerformOperation(IVisitor visitor)
    {
        foreach (var kid in Elements)
        {
            kid.Accept(visitor);
        }
    }
}



class Program
{
    static void Main(string[] args)
    {
        School school = new School();


        var visitor1 = new Doctor("James");
        school.PerformOperation(visitor1);
        Console.WriteLine();




        var visitor2 = new Nurse("Jane");
        school.PerformOperation(visitor2);
        Console.Read();
    }
}