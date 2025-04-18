using System;
using UnityEngine;

[Serializable]
public class HelicopterInput
{
    // https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQqax7M7u1GYGRZvNKuPdz_SI_cmYl5gzGKAsY6-fqiaLTf2_F6tn3vhsRykCBOWPOJINo

    public float Throttle;
    public Vector2 Cyclic;
    public float Pedal;
}

public class ArcadeHelicopter : MonoBehaviour
{
    [field: SerializeField] public HelicopterInput Input    { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody      { get; private set; }
    [field: SerializeField] public float MaxLiftForce       { get; private set; } = 25000; // Newtons
    [field: SerializeField] public float TailForce          { get; private set; } = 2f;
    [field: SerializeField] public float CyclicForce        { get; private set; } = 2f;

    // public Vector3 upForce;

    public void UpdatePhysics()
    {
        // Up/Down
        Vector3 upForce = transform.up * MaxLiftForce * Input.Throttle;
        Rigidbody.AddForce(upForce, ForceMode.Force);

        // Rotation
        Rigidbody.AddTorque(Vector3.up * Input.Pedal * TailForce, ForceMode.Acceleration);

        // Forward/Back/Left/Right
        float cyclicZForce = -1 * Input.Cyclic.x * CyclicForce;
        Rigidbody.AddRelativeTorque(Vector3.forward * cyclicZForce, ForceMode.Acceleration);

        float cyclicXForce = 1 * Input.Cyclic.y * CyclicForce;
        Rigidbody.AddRelativeTorque(Vector3.right * cyclicXForce, ForceMode.Acceleration);
    }

    public void ReadInput()
    {
        Vector2 cyclic      = new Vector2(GetAxis(Input.Cyclic.x, KeyCode.A, KeyCode.D), GetAxis(Input.Cyclic.y, KeyCode.S, KeyCode.W));
        cyclic              = Vector2.ClampMagnitude(cyclic, 1);

        Input.Cyclic        = cyclic;
        Input.Throttle      = GetAxis(Input.Throttle, KeyCode.DownArrow, KeyCode.UpArrow, false);
        Input.Pedal         = GetAxis(Input.Pedal, KeyCode.Q, KeyCode.E);
    }

    // You could create an Axis "Throttle" in Unity Editor and use Input.GetAxis("Throttle),'
    // this method will work the same way.
    float GetAxis(float currentValue, KeyCode negativeButton, KeyCode positiveButton, bool attractToZero = true)
    {
        float newValue;
        if      (UnityEngine.Input.GetKey(negativeButton))  newValue = Mathf.MoveTowards(currentValue, -1f, 1.4f * Time.deltaTime);
        else if (UnityEngine.Input.GetKey(positiveButton))  newValue = Mathf.MoveTowards(currentValue,  1f, 1.4f * Time.deltaTime);
        else
        {
            if(attractToZero)   newValue = Mathf.MoveTowards(currentValue, 0f, 1.4f * Time.deltaTime);
            else                newValue = currentValue;
        }                                                
        return newValue;
    }
}

// Bit thanks to Indie-Pixel
// If you want to learn much more deeper, check out the course: Learn how to create Helicopter physics for Games with Unity 3D and C#!
