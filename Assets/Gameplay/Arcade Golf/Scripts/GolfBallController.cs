// Big Thanks to James Doyle (Learn To Create A Minigolf Game in Unity & C#)
using UnityEngine;

public class GolfBallController : MonoBehaviour
{
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    const float minimumSpeed = 0.7f;
    const float stopSpeed = 0.97f;

    public void Hit(Vector3 direction, float HitForce)
    {
        Rigidbody.linearVelocity = direction * HitForce;
    }
}
