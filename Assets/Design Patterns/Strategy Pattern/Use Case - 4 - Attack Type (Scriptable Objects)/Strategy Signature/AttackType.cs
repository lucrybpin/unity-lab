using UnityEngine;

public abstract class AttackType : ScriptableObject
{
    public string AttackName;
    public int Damage;

    public abstract void ExecuteAttack(GameObject target);
}
