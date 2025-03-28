using UnityEngine;

[CreateAssetMenu(fileName = "IceAttack", menuName = "Scriptable Objects/IceAttack")]
public class IceAttack : AttackType
{
    public float slowAmount = 0.25f;
    public float slowDuration = 3.4f;
    public override void ExecuteAttack(GameObject target)
    {
        string slowPercentText = (slowAmount * 100).ToString() + "%";
        Debug.Log($">>>> target received {Damage} damage from Ice Attack and is slowed (-{slowPercentText} movement speed) for {slowDuration} seconds. ");
    }
}
