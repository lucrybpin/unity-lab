using UnityEngine;

public class Capsule : MonoBehaviour, IObserver
{
    [SerializeField] private IBroadcaster _broadcaster;

    void Awake()
    {
        IBroadcaster broadcaster = GameObject.FindFirstObjectByType<Sphere>() as IBroadcaster;
        broadcaster.AddObserver(this);
    }

    public void Execute()
    {
        Debug.Log($">>>> Capsule listened and is now executing!");
    }
}
