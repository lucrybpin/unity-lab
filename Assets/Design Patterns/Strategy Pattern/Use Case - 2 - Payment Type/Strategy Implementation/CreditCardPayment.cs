using UnityEngine;

// Notice that I don't name CreditCardPaymentMethods.
// You will find different names, what really is important is that you can see the pattern happening in this implementation
public class CreditCardPayment : PaymentMethod
{
    public override void Process(float amount)
    {
        // Clients with credit card receive
        Debug.Log($">>>> Paying {amount} with credit card...");
    }
}
