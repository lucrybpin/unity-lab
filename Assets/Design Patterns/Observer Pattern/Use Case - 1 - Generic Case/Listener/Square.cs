using UnityEngine;

public class Square : MonoBehaviour, IObserver
{
    [SerializeField] private IBroadcaster _broadcaster;

    void Awake()
    {
        IBroadcaster broadcaster = GameObject.FindFirstObjectByType<Sphere>() as IBroadcaster;
        broadcaster.AddObserver(this);
    }

    public void Execute()
    {
        Debug.Log($">>>> Square listened and is now executing!");
    }
}