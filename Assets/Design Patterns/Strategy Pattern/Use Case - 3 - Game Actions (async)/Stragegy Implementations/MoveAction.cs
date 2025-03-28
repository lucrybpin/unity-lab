using System;
using System.Threading.Tasks;
using UnityEngine;

public class MoveAction : IGameAction
{
    public async Task Execute(GameObject actor)
    {
        Debug.Log($">>>> Moving...");
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.transform.Translate(Vector3.forward);
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.transform.Translate(Vector3.forward);
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.transform.Translate(Vector3.forward);
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.transform.Translate(Vector3.forward);
    }
}
