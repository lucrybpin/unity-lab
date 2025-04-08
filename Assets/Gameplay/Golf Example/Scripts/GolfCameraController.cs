using UnityEngine;

public enum RotationDirection { Left, Right }

public class GolfCameraController : MonoBehaviour
{
    [field: SerializeField] public Transform    Target          { get; private set; }
    [field: SerializeField] public float        Rotation        { get; private set; }
    [field: SerializeField] public float        RotationSpeed   { get; private set; }

    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Quaternion.Euler(0f, Rotation, 0f);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

    public void Rotate(RotationDirection direction)
    {
        if(direction == RotationDirection.Left)
            Rotation -= RotationSpeed * Time.deltaTime;
        else
            Rotation += RotationSpeed * Time.deltaTime;
    }
}