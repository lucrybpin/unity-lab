using UnityEngine;

public class ArcadeCarTopCameraTrigger : MonoBehaviour
{
    [field: SerializeField] public ArcadeVehicleCamera ArcadeCarCamera { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<IArcadeVehicle>(out IArcadeVehicle vehicle))
        {
            ArcadeCarCamera.SetTopMode();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<IArcadeVehicle>(out IArcadeVehicle vehicle))
        {
            ArcadeCarCamera.SetNormalMode();
        }
    }
}
