using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    [field: SerializeField] public Transform Target     { get; private set; }
    [field: SerializeField] public float Distance       { get; private set; } = 3f;
    [field: SerializeField] public float Sensitivity    { get; private set; } = 140f;
    [field: SerializeField] public Vector2 CameraAngles { get; private set; }
    public Vector2 CameraInput                          { get; private set; }

    void Awake()
    {
        CameraAngles = new Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
    }

    void LateUpdate()
    {
        // Read Mouse Input
        CameraInput = new Vector2(Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X"));

        // Convert Input to 3D Angles
        CameraAngles += CameraInput * Sensitivity * Time.deltaTime;
        CameraAngles = new Vector2(Mathf.Clamp(CameraAngles.x, -30f, 90f), CameraAngles.y);

        // Convert 3D Angles to Game Angles 
        Quaternion cameraAnglesInQuaternion = Quaternion.Euler(CameraAngles);

        // Look = Project Ray forward from current angle
        Vector3 lookDireciton = cameraAnglesInQuaternion * Vector3.forward;

        // Position = Inverse of vetor Look starting from target position
        Vector3 cameraPosition = Target.position - lookDireciton * Distance;

        // Collision
        if(Physics.Raycast(Target.position, -lookDireciton, out RaycastHit hitInfo, Distance))
        {
            cameraPosition = Target.position - lookDireciton * hitInfo.distance * 0.94f;
        }

        transform.SetPositionAndRotation(cameraPosition, cameraAnglesInQuaternion);
    }
}
