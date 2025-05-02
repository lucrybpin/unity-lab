// Big Thanks to James Doyle (Learn To Create A Minigolf Game in Unity & C#)
using UnityEngine;

public class GolfGameController : MonoBehaviour
{
    [field: SerializeField] public GolfBallController   BallController      { get; private set; }
    [field: SerializeField] public GolfCameraController CameraController    { get; private set; }
    [field: SerializeField] public float HitForce { get; private set; }

    void Start()
    {
        CameraController.SetTarget(BallController.transform);
    }

    void Update()
    {
        // Hit the Ball
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = CameraController.transform.forward;
            BallController.Hit(direction, HitForce);
        }

        // Camera Controls
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            CameraController.Rotate(RotationDirection.Left);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            CameraController.Rotate(RotationDirection.Right);
        }
    }
}