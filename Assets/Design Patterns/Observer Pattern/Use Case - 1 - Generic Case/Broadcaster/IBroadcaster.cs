using System.Collections.Generic;

public interface IBroadcaster
{
    public List<IObserver> Observers { get; set; }

    public void AddObserver(IObserver observer);

    public void Broadcast();
}
