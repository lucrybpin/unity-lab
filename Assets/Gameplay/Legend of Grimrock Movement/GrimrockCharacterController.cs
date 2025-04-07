using DG.Tweening;
using UnityEngine;

public class GrimrockCharacterController : MonoBehaviour
{
    private bool _isMoving = false;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(_isMoving)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            _isMoving = true;
            transform.DOLocalMove(transform.position + 2 * transform.forward, .57f).OnComplete(() => _isMoving = false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _isMoving = true;
            transform.DOLocalMove(transform.position + -2 * transform.forward, .57f).OnComplete(() => _isMoving = false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _isMoving = true;
            transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(0, 90f, 0f), 0.43f).OnComplete(() => _isMoving = false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _isMoving = true;
            transform.DOLocalRotate(transform.rotation.eulerAngles + new Vector3(0, -90f, 0f), 0.43f).OnComplete(() => _isMoving = false);
        }
    }
}
