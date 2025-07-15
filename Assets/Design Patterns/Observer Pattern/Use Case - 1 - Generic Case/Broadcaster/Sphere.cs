using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

// There is a lot of room for improvements here, but I believe this is the
// simplest example possible, with minimum noise and distractions
public class Sphere : MonoBehaviour, IBroadcaster
{
    public List<IObserver> Observers { get ; set ; }

    public void AddObserver(IObserver observer)
    {
        if(Observers == null)
            Observers = new List<IObserver>();

        Observers.Add(observer);
    }

    // If onde of the observers is removed from memory when we try to broadcast an error will occur
    // because it is trying to call the method from a dead reference. Always Remove OnDestroy or when it
    // it is being removed from memory
    public void RemoveObserver(IObserver observer)
    {
        Observers.Remove(observer);
    }

    public void Broadcast()
    {
        foreach (IObserver observer in Observers)
            observer.Execute();
    }

    async void Start()
    {
        await Task.Delay(TimeSpan.FromSeconds(2f));
        GameStart();
    }

    void GameStart()
    {
        Debug.Log($">>>> Game Started");
        Broadcast();
    }
}
