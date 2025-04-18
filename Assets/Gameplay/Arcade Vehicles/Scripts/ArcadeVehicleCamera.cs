using UnityEngine;

public enum ArcadeVehicleCameraMode
{
    Top,
    Normal
}

public class ArcadeVehicleCamera : MonoBehaviour
{
    [field: SerializeField] public IArcadeVehicle Vehicle               { get; private set; }
    [field: SerializeField] public ArcadeVehicleCameraMode CameraMode   { get; private set; } = ArcadeVehicleCameraMode.Normal;
    
    public Vector3 normalOffset = new Vector3(0, 2f, -3f);
    public Vector3 topOffset = new Vector3(0, 10f, 0);

    public void Setup(IArcadeVehicle vehicle)
    {
        Vehicle = vehicle;
        CameraMode = ArcadeVehicleCameraMode.Normal;
    }

    public void OnLateFixedUpdate()
    {
        Vector3 targetPosition;
        float currentSmoothTime;
        
        switch (CameraMode)
        {
            default:
            case ArcadeVehicleCameraMode.Normal:
                targetPosition = Vehicle.GameObject.transform.position + 
                                Vehicle.GameObject.transform.forward * Vehicle.CameraPosition.z +
                                Vehicle.GameObject.transform.up * Vehicle.CameraPosition.y +
                                Vehicle.GameObject.transform.right * Vehicle.CameraPosition.x;
                currentSmoothTime = .7f;
                break;
            
            case ArcadeVehicleCameraMode.Top:
                targetPosition = Vehicle.GameObject.transform.position + topOffset;
                currentSmoothTime = 0.25f;
                break;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSmoothTime);
        transform.LookAt(Vehicle.GameObject.transform.position);
    }

    public void SetTopMode()
    {
        CameraMode = ArcadeVehicleCameraMode.Top;
    }

    public void SetNormalMode()
    {
        CameraMode = ArcadeVehicleCameraMode.Normal;
    }
}