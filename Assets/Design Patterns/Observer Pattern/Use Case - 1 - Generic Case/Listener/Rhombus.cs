using UnityEngine;

public class Rhombus : MonoBehaviour, IObserver
{
    [SerializeField] private IBroadcaster _broadcaster;

    void Awake()
    {
        // This violates Dependency Injection, but for now worry about understanding what we are trying to achieve
        _broadcaster = GameObject.FindFirstObjectByType<Sphere>() as IBroadcaster;
        _broadcaster.AddObserver(this);
    }

    void OnDestroy()
    {
        _broadcaster.RemoveObserver(this);
    }

    public void Execute()
    {
        Debug.Log($">>>> Rhombus listened and is now executing!");
    }
}