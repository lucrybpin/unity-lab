public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    public abstract string GetName();
    public abstract float GetPrice();
}
