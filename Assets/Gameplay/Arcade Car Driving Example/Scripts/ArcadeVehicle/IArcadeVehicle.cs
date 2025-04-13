using System.Collections.Generic;
using UnityEngine;

public interface IArcadeVehicle
{
    VehicleInput Input                  { get; set; }
    Rigidbody Rigidbody                 { get; set; }
    Vector3 CenterOfMass                { get; set; }
    Vector3 CameraPosition              { get; set; }
    GameObject GameObject               { get; set; }
    List<ArcadeVehicleWheel> Wheels     { get; set; }

    void OnStart();
    void ReadInput();
    void UpdatePhysics();
}
