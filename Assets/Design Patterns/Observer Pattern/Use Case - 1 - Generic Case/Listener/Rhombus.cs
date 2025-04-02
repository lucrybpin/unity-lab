using UnityEngine;

public class Rhombus : MonoBehaviour, IObserver
{
    [SerializeField] private IBroadcaster _broadcaster;

    void Awake()
    {
        // This violates Dependency Injection, but for now worry about understanding what we are trying to achieve
        IBroadcaster broadcaster = GameObject.FindFirstObjectByType<Sphere>() as IBroadcaster;
        broadcaster.AddObserver(this);
    }

    public void Execute()
    {
        Debug.Log($">>>> Rhombus listened and is now executing!");
    }
}