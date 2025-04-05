using UnityEngine;

public class DoorSimpleStateMachine : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _speed;
    Vector3 moveDirection;

    void Update()
    {
        Vector2 input = ReadInput();
        bool jump = Input.GetKey(KeyCode.Space);

        if(_characterController.isGrounded)
        {
            moveDirection = transform.forward * input.y + transform.right * input.x;
            moveDirection.Normalize();
            moveDirection *= _speed;
            moveDirection.y = 0f;

            if(jump)
                moveDirection.y = 4.3f;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime; // gravidade é uma aceleração m/s^2 então multiplicamos aqui e depois novamente
        _characterController.Move(moveDirection *  Time.deltaTime);
    }

    Vector2 ReadInput()
    {
        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        input = Vector2.ClampMagnitude(input, 1f);
        return input;
    }
}
