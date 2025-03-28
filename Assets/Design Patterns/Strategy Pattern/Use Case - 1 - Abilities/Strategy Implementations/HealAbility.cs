using UnityEngine;

public class HealAbility : IAbility
{
    public void Execute()
    {
        Debug.Log($">>>> I am healed!");
    }
}
