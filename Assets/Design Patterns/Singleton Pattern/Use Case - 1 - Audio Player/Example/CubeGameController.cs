using UnityEngine;

public class CubeGameController : MonoBehaviour
{
    [SerializeField] Transform _playerCube;
    [SerializeField] AudioClip _funnySound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerCube.Translate(Vector3.right);
            AudioPlayer.Instance.PlayClip(_funnySound);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerCube.Translate(Vector3.left);
            AudioPlayer.Instance.PlayClip(_funnySound);
        }
    }
}
