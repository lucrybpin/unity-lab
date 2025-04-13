using UnityEngine;

public enum ArcadeVehicleOption
{
    SimpleCar,
    Truck,
    Van
}

public class ArcadeVehicleSceneController : MonoBehaviour
{
    [field: SerializeField] public ArcadeCar ArcadeSimpleCar                { get; private set; }
    [field: SerializeField] public ArcadeTruck ArcadeTruck                  { get; private set; }
    [field: SerializeField] public ArcadeVan ArcadeVan                      { get; private set; }
    [field: SerializeField] public ArcadeVehicleCamera VehicleCamera        { get; private set; }
    [field: SerializeField] public ArcadeVehicleSpeedometer Speedometer     { get; private set; }
    [field: SerializeField] private IArcadeVehicle _currentVehicle;

    void Start()
    {
        SetVehicle(ArcadeVehicleOption.SimpleCar);
        ArcadeSimpleCar.OnStart();
        ArcadeTruck.OnStart();
        ArcadeVan.OnStart();
    }

    void Update()
    {
        _currentVehicle.ReadInput();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetVehicle(ArcadeVehicleOption.SimpleCar);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            SetVehicle(ArcadeVehicleOption.Truck);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetVehicle(ArcadeVehicleOption.Van);
        }
    }

    void FixedUpdate()
    {
        _currentVehicle.UpdatePhysics();
        VehicleCamera.OnLateFixedUpdate();
    }

    public IArcadeVehicle SetVehicle(ArcadeVehicleOption vehicleOption)
    {
        IArcadeVehicle vehicle;
        switch (vehicleOption)
        {
            case ArcadeVehicleOption.SimpleCar:
            default:
                vehicle = (IArcadeVehicle) ArcadeSimpleCar;
                break;

            case ArcadeVehicleOption.Truck:
                vehicle = (IArcadeVehicle) ArcadeTruck;
                break;

            case ArcadeVehicleOption.Van:
                vehicle = (IArcadeVehicle) ArcadeVan;
                break;
        }

        VehicleCamera.Setup(vehicle);
        Speedometer?.Setup(vehicle);
        _currentVehicle = vehicle;
        return vehicle;
    }

    void LateUpdate()
    {
        // VehicleCamera.OnLateUpdate();
        Speedometer?.OnLateUpdate();
    }
}
