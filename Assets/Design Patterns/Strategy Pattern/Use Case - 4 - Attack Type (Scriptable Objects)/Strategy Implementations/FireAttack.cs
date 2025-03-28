using UnityEngine;

[CreateAssetMenu(fileName = "FireAttack", menuName = "Scriptable Objects/FireAttack")]
public class FireAttack : AttackType
{
    public float burnDuration = 2f;

    public override void ExecuteAttack(GameObject target)
    {
        Debug.Log($">>>> target received {Damage} damage from Fire Attack and is now burning for {burnDuration} seconds");
    }
}
