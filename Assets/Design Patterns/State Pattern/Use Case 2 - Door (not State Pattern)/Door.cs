using UnityEngine;

// The state pattern help us to build a State Machine
// but in this example we created a state MACHINE
// WITHOUT the use of the state PATTERN
// For this ultra simmple case, this is enough
public class Door : MonoBehaviour
{
    [SerializeField] DoorState _currentState;
    [SerializeField] DoorView _view;

    void Awake()
    {
        _currentState = DoorState.Closed;
    }

    void OnMouseDown()
    {
        switch (_currentState)
        {
            case DoorState.Open:
                CloseDoor();
            break;
            case DoorState.Closed:
                OpenDoor();
            break;
        }
    }

    void OpenDoor()
    {
        _currentState = DoorState.Open;
        _view.OpenDoor();
    }

    void CloseDoor()
    {
        _currentState = DoorState.Closed;
        _view.CloseDoor();
    }
}