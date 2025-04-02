using System;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    // Here we have 2 observer examples.
    // First is the LoginClick (line 25) method observing the onClick. (line 22))
    // Second is the Toast Show method listening to 
    // the event OnLoginClick (line 14))

    [SerializeField] Button _loginButton;

    public event Action OnLoginClick; // the event

    void Awake()
    {
        // the method LoginClick is an observer
        // to the onClick event
        // The Button component from _loginButton 
        // broadcast the event onClick
        _loginButton.onClick.AddListener(LoginClick);
    }

    void LoginClick()
    {
        Debug.Log($">>>> Login Click");
        OnLoginClick?.Invoke(); // Broadcasting
    }
}
