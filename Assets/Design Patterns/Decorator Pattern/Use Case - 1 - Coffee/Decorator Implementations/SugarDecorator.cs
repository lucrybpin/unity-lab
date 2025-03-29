public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public override string GetName()
    {
        return _coffee.GetName() + " + sugar";
    }

    public override float GetPrice()
    {
        return _coffee.GetPrice() + 0.25f;
    }
}
