using UnityEngine;

public class ChickenController25D : MonoBehaviour
{
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public SpriteRenderer SpriteRenderer { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    [SerializeField] Vector3 MoveDirection;
    float lastDirectionX = 1f;
    Vector3 originalScale;
    
    void Start()
    {
        originalScale = transform.localScale; // Guarda a escala inicial
    }

    public void HandleUpdate()
    {
        MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        MoveDirection.Normalize();
        MoveDirection *= 2f;

        if (Mathf.Abs(MoveDirection.x) > 0.1f)
        {
            lastDirectionX = Mathf.Sign(MoveDirection.x);
        }

        Vector3 newScale = originalScale;
        if (lastDirectionX > 0) 
        {
            newScale.x = -originalScale.x; 
        }
        transform.localScale = newScale;

        Animator.SetFloat("speed", CharacterController.velocity.magnitude);

        CharacterController.Move(MoveDirection * Time.deltaTime);
    }
}
