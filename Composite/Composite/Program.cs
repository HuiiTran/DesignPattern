//component 
public abstract class GiftBase
{
    protected string name;
    protected int price;

    public GiftBase(string name, int price)
    {
        this.name = name;
        this.price = price;
    }

    public abstract int CalculateTotalPrice();
}
//6
public interface IGiftOperations
{
    void Add(GiftBase gift);
    void Remove(GiftBase gift);
}
//composite 
public class CompositeGift : GiftBase, IGiftOperations
{
    private List<GiftBase> _gifts;

    public CompositeGift(string name, int price)
        : base(name, price)
    {
        _gifts = new List<GiftBase>();
    }

    public void Add(GiftBase gift)
    {
        _gifts.Add(gift);
    }

    public void Remove(GiftBase gift)
    {
        _gifts.Remove(gift);
    }

    public override int CalculateTotalPrice()
    {
        int total = 0;

        Console.WriteLine($"{name} contains the following products with prices:");

        foreach (var gift in _gifts)
        {
            total += gift.CalculateTotalPrice();
        }

        return total;
    }
}
//leaf 
public class SingleGift : GiftBase
{
    public SingleGift(string name, int price)
        : base(name, price)
    {
    }

    public override int CalculateTotalPrice()
    {
        Console.WriteLine($"{name} with the price {price}");

        return price;
    }
}
//client 
class Program
{
    static void Main(string[] args)
    {

        //composite gift
        //rootBox
        var rootBox = new CompositeGift("RootBox", 0);
        var truckToy = new SingleGift("Gundam", 300);
        var plainToy = new SingleGift("HarryPotter series", 600);
        rootBox.Add(truckToy);
        rootBox.Add(plainToy);

        //child box 
        var childBox = new CompositeGift("ChildBox", 0);
        var soldierToy = new SingleGift("Nitendo Switch", 200);
        childBox.Add(soldierToy);


        rootBox.Add(childBox);
        Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
    }
}
