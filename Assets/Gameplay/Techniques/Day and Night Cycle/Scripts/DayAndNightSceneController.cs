using UnityEngine;

public class DayAndNightSceneController : MonoBehaviour
{
    [field: SerializeField] public SkyController SkyController { get; private set; }

    void Update()
    {
        SkyController.UpdateSky();
    }
}
