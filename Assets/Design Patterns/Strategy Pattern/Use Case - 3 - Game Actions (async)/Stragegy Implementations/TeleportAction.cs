
using System;
using System.Threading.Tasks;
using UnityEngine;

public class TeleportAction : IGameAction
{
    Vector3 _destination;

    public TeleportAction(Vector3 destination)
    {
        _destination = destination;
    }

    public async Task Execute(GameObject actor)
    {
        Debug.Log($">>>> Teleporting!");
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.transform.position = _destination;
    }
}
