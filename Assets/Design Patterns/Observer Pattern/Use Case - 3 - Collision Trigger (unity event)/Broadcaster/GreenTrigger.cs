using UnityEngine;
using UnityEngine.Events;

public class GreenTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnAnythingEnter; // Check on this is set in the inspector

    void OnTriggerEnter(Collider other)
    {
        OnAnythingEnter?.Invoke(); // Broadcast
    }
}
