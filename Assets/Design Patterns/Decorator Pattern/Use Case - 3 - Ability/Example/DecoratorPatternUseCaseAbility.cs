using UnityEngine;

public class DecoratorPatternUseCaseAbility : MonoBehaviour
{
    void Start()
    {
        IAbility ability = new FireballAbility();

        // Add Decorator
        ability = new DelayedAbility(ability);
        ability.Execute();
    }
}
