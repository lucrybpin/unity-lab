using System;
using System.Threading.Tasks;
using UnityEngine;

// In the previous examples we implemented the decorator signature
// here I am not using the signature and just directly wrapping the
// thing. 

// The important thing is that we are still implementing the Decorator
// Pattern, dont get attached to code, but what it does.

public class DelayedAbility : IAbility
{
    IAbility _ability;

    public DelayedAbility(IAbility ability)
    {
        _ability = ability;
    }

    public void Execute()
    {
        _ = Delay(_ability.Execute);
    }

    async Task Delay(Action onFinish)
    {
        Debug.Log($">>>> Delaying Ability...");
        await Task.Delay(TimeSpan.FromSeconds(7f));
        onFinish?.Invoke();
    }
}
