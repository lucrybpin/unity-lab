using UnityEngine;
using UnityEngine.UI;

public class ButtonPlaySound : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] AudioClip _buttonAudioClip;

    void OnEnable()
    {
        _button.onClick.AddListener(PlaySound);
    }


    void OnDisable()
    {
        _button.onClick.RemoveListener(PlaySound);
    }

    private void PlaySound()
    {
        AudioPlayer.Instance.PlayClip(_buttonAudioClip);
    }
}
