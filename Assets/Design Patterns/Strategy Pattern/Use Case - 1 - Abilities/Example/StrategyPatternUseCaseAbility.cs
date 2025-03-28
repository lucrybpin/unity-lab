using UnityEngine;

public class StrategyPatternUseCaseAbility : MonoBehaviour
{
    void Start()
    {
        // current strategy
        IAbility currentAbility;

        // Switch strategy
        currentAbility = new FireballAbility();
        currentAbility.Execute();

        // Switch strategy
        currentAbility = new HealAbility();
        currentAbility.Execute();

        // Switch strategy
        currentAbility = new RageAbility();
        currentAbility.Execute();

        // Example code without stratregy pattern
        WithoutStrategyPattern();

    }

    private void WithoutStrategyPattern()
    {
        // This violates Open Closed Principle: we need to modify this code to add new modifications
        Abilitiy currentAbility = Abilitiy.Fireball;

        switch (currentAbility)
        {
            case Abilitiy.Fireball:
                Debug.Log($">>>> Fireball!");
                break;
            case Abilitiy.Heal:
                Debug.Log($">>>> I am healed!");
                break;
            case Abilitiy.Rage:
                Debug.Log($">>>> I am super raged!");
                break;
        }
    }
}

public enum Abilitiy
{
    Fireball,
    Heal,
    Rage
}