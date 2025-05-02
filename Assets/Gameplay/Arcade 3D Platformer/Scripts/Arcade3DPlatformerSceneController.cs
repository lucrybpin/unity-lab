using System;
using UnityEngine;

public class ArcadePlatformerInput
{
    public Vector2 MoveDirection;
    public bool IsPressingMovement;
    public bool Jump;
}

public class Arcade3DPlatformerSceneController : MonoBehaviour
{
    [field: SerializeField] public OrbitalCamera OrbitalCamera                      { get; private set; }
    [field: SerializeField] public Arcade3DPlatformerPlayerController Player        { get; private set; }

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Player.ReadInput();
        Player.UpdatePhysics(OrbitalCamera);
    }
}
