using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    // Singletons are sometimes needed but they are dangerous.

    // The goal is simple: garantee that you have only one instance
    // of the thing in the game, Must not exist any scenario
    // where you have two AudioPlayer for example but oftenly
    // we thing there could be only one instance and later
    // you end up needing more than one.

    // People usually complain about singleton just because everyone
    // is repeating the same thing. They are right but I am afraid 
    // they have no idea why at all.
    // You can avoid using singletons with a Service Locator Pattern
    // or a static class or a DontDestroyOnLoad object but in almost 
    // any case you end up with the same thing: 
    // a floating public entity that is visible for any other class.

    // Multiple instances spread aroud the game calling a method
    // can (and will) cause unexpected behaviors 
    // But in Unity tt is really common that you need a global instance of
    // something that exists accross several scenes in your game
    // (Scene Loader and Audio Player for example).

    // From my experience to THIS point, my conclusion is:
    // Avoid at all costs multiple objects/Monobehaviours in your scene
    // Design your game thinking about Single Entry Point 
    // for each scene and delegate to child classes the sub tasks
    // to solve, passing all dependenies to child classes.

    public static AudioPlayer Instance { get; private set; }

    [SerializeField] AudioSource _audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Anyone can grab the Instance and call this method
    public void PlayClip(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
