using UnityEngine;

public class ArcadeHelicopterCamera : MonoBehaviour
{
    [field: SerializeField] public Transform Target { get; private set; }

    public void Setup(Transform target)
    {
        Target = target;
    }

    public void OnLateFixedUpdate()
    {
        transform.LookAt(Target);
        transform.position = Target.position - 12 * Target.transform.forward + Vector3.up * 7f;
    }
}
