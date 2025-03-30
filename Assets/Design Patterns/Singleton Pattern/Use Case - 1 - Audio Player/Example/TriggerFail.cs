using UnityEngine;

public class TriggerFail : MonoBehaviour
{
    [SerializeField] AudioClip _failSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioPlayer.Instance.PlayClip(_failSound);
        }
    }
}
