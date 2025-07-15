using UnityEngine;

public class Square : MonoBehaviour, IObserver
{
    [SerializeField] private IBroadcaster _broadcaster;

    void Awake()
    {
        _broadcaster = GameObject.FindFirstObjectByType<Sphere>() as IBroadcaster;
        _broadcaster.AddObserver(this);
    }

    void OnDestroy()
    {
        _broadcaster.RemoveObserver(this);
    }

    public void Execute()
    {
        Debug.Log($">>>> Square listened and is now executing!");
    }
}