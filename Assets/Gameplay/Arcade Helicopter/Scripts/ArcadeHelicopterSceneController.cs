using UnityEngine;

public class ArcadeHelicopterSceneController : MonoBehaviour
{
    [field: SerializeField] public ArcadeHelicopter ArcadeHelicopter    { get; private set; }
    [field: SerializeField] public ArcadeHelicopterCamera Camera        { get; private set; }

    void Start()
    {
        Camera.Setup(ArcadeHelicopter.transform);
    }

    void Update()
    {
        ArcadeHelicopter.ReadInput();
    }

    void FixedUpdate()
    {
        ArcadeHelicopter.UpdatePhysics();
        Camera.OnLateFixedUpdate();
    }
}
