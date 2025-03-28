// Notice that now I am not using an interface, like the previous examples.
// For you to understand that the interface is just a resource, not a rule of the pattern
public abstract class PaymentMethod
{
    public abstract void Process(float amount);
}
