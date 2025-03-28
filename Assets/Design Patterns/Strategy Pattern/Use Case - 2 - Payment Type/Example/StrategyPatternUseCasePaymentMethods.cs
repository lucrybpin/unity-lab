using UnityEngine;
using UnityEngine.UI;

public class StrategyPatternUseCasePaymentMethods : MonoBehaviour
{
    [SerializeField] Button _creditCardButton;
    [SerializeField] Button _googlePlayButton;

    PaymentMethod _paymentMethod;

    void Start()
    {
        _creditCardButton.onClick.AddListener(OnCreditCardClick);
        _googlePlayButton.onClick.AddListener(OnGooglePlayClick);
    }

    void OnCreditCardClick()
    {
        _paymentMethod = new CreditCardPayment();
        ProcessPayment();
    }

    void OnGooglePlayClick()
    {
        _paymentMethod = new GooglePlayBilligPayment();
        ProcessPayment();
    }

    void ProcessPayment()
    {
        _paymentMethod.Process(100);
    }
}
