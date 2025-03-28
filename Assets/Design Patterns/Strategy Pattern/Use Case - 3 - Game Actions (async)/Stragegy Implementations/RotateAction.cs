using System;
using System.Threading.Tasks;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class RotateAction : IGameAction
{
    public async Task Execute(GameObject actor)
    {
        float deltaAngle = 90f;
        Quaternion startRotation = actor.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(actor.transform.rotation.eulerAngles + new Vector3(0f, deltaAngle, 0f));

        float elapsedTime = 0f;
        float totalTime = 1f;

        Debug.Log($">>>> Rotating...");
        await Task.Delay(TimeSpan.FromSeconds(1));

        // Quaternion lerp
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            actor.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime/totalTime);
            await Task.Yield();
        }

        actor.transform.rotation = endRotation;
    }
}
