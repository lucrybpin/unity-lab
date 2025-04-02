using System;
using System.Threading.Tasks;
using UnityEngine;

public class Toast : MonoBehaviour
{
    [SerializeField] Login _login;
    [SerializeField] RectTransform _rectTransform;

    void Awake()
    {
        _login.OnLoginClick += Show; // Observing the OnLoginClick event
    }

    [ContextMenu("Show")]
    private async void Show()
    {
        float elapsedTime = 0f;
        float totalTime = 0.125f;

        // Show
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            float currentY = Mathf.Lerp(-50f, 50f, elapsedTime/totalTime);
            Vector2 anchoredPosition = new Vector3(0f, currentY, 0f);
            _rectTransform.anchoredPosition = anchoredPosition;
            await Task.Yield();
        }

        await Task.Delay(TimeSpan.FromSeconds(4.3f));

        elapsedTime = 0f;
        totalTime = .25f;

        // Hide
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            float currentY = Mathf.Lerp(50f, -50f, elapsedTime/totalTime);
            Vector2 anchoredPosition = new Vector3(0f, currentY, 0f);
            _rectTransform.anchoredPosition = anchoredPosition;
            await Task.Yield();
        }
    }
}
