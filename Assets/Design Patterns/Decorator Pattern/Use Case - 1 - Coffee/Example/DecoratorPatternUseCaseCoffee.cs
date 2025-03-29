using UnityEngine;

public class DecoratorPatternUseCaseCoffee : MonoBehaviour
{
    void Start()
    {
        ICoffee coffee = new SimpleCoffee();

        Debug.Log($">>>> {coffee.GetName()} \t\t\t\t price: ${coffee.GetPrice()}");

        // Added Decorator
        coffee = new MilkDecorator(coffee);
        Debug.Log($">>>> {coffee.GetName()} \t\t price: ${coffee.GetPrice()}");

        // Added Decorator
        coffee = new SugarDecorator(coffee);
        Debug.Log($">>>> {coffee.GetName()} \t price: ${coffee.GetPrice()}");
    }
}
