using UnityEngine;

public class HealActionListener : MonoBehaviour
{
    // This is our action, and we connected (bind) it to the Green Trigger OnEnter event
    // trigger via inspector. Check the the GreenTrigger object in the scene via inspector
    public void Execute()
    {
        Debug.Log($">>>> Healed!");
    }
}
