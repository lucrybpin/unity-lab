using UnityEngine;

public class GooglePlayBilligPayment : PaymentMethod
{
    public override void Process(float amount)
    {
        amount *= 0.9f;
        Debug.Log($">>>> Paying {amount} with Google Play... received 10% discount");
    }
}
