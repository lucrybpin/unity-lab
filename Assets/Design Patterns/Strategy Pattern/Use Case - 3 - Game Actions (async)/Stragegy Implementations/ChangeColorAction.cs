using System;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeColorAction : IGameAction
{
    public async Task Execute(GameObject actor)
    {
        Debug.Log($">>>> Changing Color...");
        await Task.Delay(TimeSpan.FromSeconds(1));

        actor.GetComponent<MeshRenderer>()
            .material.color = Color.yellow;
    }
}
