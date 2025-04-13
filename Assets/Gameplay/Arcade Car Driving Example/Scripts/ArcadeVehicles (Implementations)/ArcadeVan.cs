using System.Collections.Generic;
using UnityEngine;

public class ArcadeVan : MonoBehaviour, IArcadeVehicle
{
    [Header("IArcadeVehicle")]
    [field: SerializeField] public VehicleInput Input               { get; set; }
    [field: SerializeField] public Rigidbody Rigidbody              { get; set; }
    [field: SerializeField] public Vector3 CenterOfMass             { get; set; }
    [field: SerializeField] public Vector3 CameraPosition           { get; set; }
    [field: SerializeField] public GameObject GameObject            { get; set; }
    [field: SerializeField] public List<ArcadeVehicleWheel> Wheels  { get; set; }

    [field: SerializeField] public float Torque                     { get; private set; } = 4300;
    [field: SerializeField] public float TopSpeed                   { get; private set; } = 50;
    [field: SerializeField] public float MaxSteeringAngle           { get; private set; } = 30f;
    [field: SerializeField] public float BrakeAcceleration          { get; private set; } = 10000f;

    Quaternion _wheelRot;
    Vector3 _wheelPos;

    public void OnStart()
    {
        Rigidbody.centerOfMass = CenterOfMass;
    }

    public void ReadInput()
    {
        VehicleInput input  = new VehicleInput();
        input.Acceleration  = UnityEngine.Input.GetAxis("Vertical");
        input.Steering      = UnityEngine.Input.GetAxis("Horizontal");
        input.Braking       = UnityEngine.Input.GetKey(KeyCode.Space);
        Input               = input;
    }

    public void UpdatePhysics()
    {
        float speed = Rigidbody.linearVelocity.magnitude * 3.6f;

        // Speed Limit and Energy Reduction
        if(Input.Acceleration == 0 || speed > TopSpeed)
            Rigidbody.linearVelocity *= 0.99f;

        foreach (ArcadeVehicleWheel wheel in Wheels)
        {
            // Brakes
            if (Input.Braking)  wheel.Collider.brakeTorque = BrakeAcceleration;
            else                wheel.Collider.brakeTorque = 0f;

            if (wheel.Axel == ArcadeVehicleAxel.Front)
            {
                // Accelerate
                if (speed < TopSpeed)
                    wheel.Collider.motorTorque = Torque * Input.Acceleration;

                // Turn
                wheel.Collider.steerAngle = MaxSteeringAngle * Input.Steering;
            }

            //View
            wheel.Collider.GetWorldPose(out _wheelPos, out _wheelRot);
            wheel.View.transform.position = _wheelPos;
            wheel.View.transform.rotation = _wheelRot;
        }
    }
}
