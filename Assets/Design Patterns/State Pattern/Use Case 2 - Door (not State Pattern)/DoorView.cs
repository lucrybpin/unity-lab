using UnityEngine;

public class DoorView : MonoBehaviour
{
    [SerializeField] Transform _transform;

    public void OpenDoor()
    {
        _transform.rotation = Quaternion.Euler(new Vector3(0f, 80f, 0f));
    }

    public void CloseDoor()
    {
        _transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
    }
}
