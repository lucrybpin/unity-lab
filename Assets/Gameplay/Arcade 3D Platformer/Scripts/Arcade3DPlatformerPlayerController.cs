using UnityEngine;

public class Arcade3DPlatformerPlayerController : MonoBehaviour
{
    [field: SerializeField] public ArcadePlatformerInput Input              { get; private set; } = new ArcadePlatformerInput();
    [field: SerializeField] public CharacterController CharacterController  { get; private set; }
    [field: SerializeField] public float MovementSpeed                      { get; private set; } = 10f;
    [field: SerializeField] public float JumpForce                          { get; private set; } = 7f;
    [field: SerializeField] public float GravityScale                       { get; private set; } = 7f;

    private Vector3 _moveDirection;
    private float _yVelocity = 0f;

    public void UpdatePhysics(OrbitalCamera camera)
    {
        if(Input.IsPressingMovement)
        {
            float inputAngle    = Mathf.Atan2(Input.MoveDirection.x, Input.MoveDirection.y) * Mathf.Rad2Deg;
            float cameraAngle   = camera.transform.rotation.eulerAngles.y;
            float playerAngle   = inputAngle + cameraAngle;
            float finalAngle    = Mathf.LerpAngle(transform.rotation.eulerAngles.y, playerAngle, 34 * Time.deltaTime);
            transform.rotation  = Quaternion.Euler(0f, finalAngle, 0f);
        }

        _yVelocity              = _moveDirection.y;
        _moveDirection          = MovementSpeed *  transform.forward * Input.MoveDirection.magnitude;
        _moveDirection.y        = _yVelocity;

        if(CharacterController.isGrounded)
        {
            _moveDirection.y = 0f;

            if(Input.Jump)
                _moveDirection.y = JumpForce;
        }

        // Apply Gravity
        _moveDirection.y += GravityScale * Physics.gravity.y * Time.deltaTime;

        CharacterController.Move(_moveDirection * Time.deltaTime);
    }

    public void ReadInput()
    {
        Vector2 inputDirection      =  new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));
        Input.MoveDirection         = Vector2.ClampMagnitude(inputDirection, 1f);
        Input.IsPressingMovement    = UnityEngine.Input.GetAxisRaw("Vertical") != 0f || UnityEngine.Input.GetAxisRaw("Horizontal") != 0f;
        Input.Jump                  = UnityEngine.Input.GetKeyDown(KeyCode.Space);
    }
}