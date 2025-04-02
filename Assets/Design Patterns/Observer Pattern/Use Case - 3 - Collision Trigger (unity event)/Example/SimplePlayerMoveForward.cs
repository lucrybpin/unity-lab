using UnityEngine;

public class SimplePlayerMoveForward : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate( new Vector3(0, 0, Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate( new Vector3(0, 0, -Time.deltaTime));
        }
    }
}
