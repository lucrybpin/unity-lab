public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public override string GetName()
    {
        return _coffee.GetName() + " + milk";
    }

    public override float GetPrice()
    {
        return _coffee.GetPrice() + 0.5f;
    }
}
