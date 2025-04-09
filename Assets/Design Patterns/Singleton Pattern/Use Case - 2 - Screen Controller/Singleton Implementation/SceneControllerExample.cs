
// This time I am inheriting from my Singleton class, a custom utils
// to make it easier.
// And in this scenario I am correctly using Singleton because my purpose
// Is only to garantee a single Instance of this.
// I don't need anyone acessing this Instance because this is the Single
// Entry Point of the scene, every other script related to scene behavior
// should be here and if they need this as a variable, we send inject the dependency
// to the needing childs.

// I Will discuss more about this later

public class SceneControllerExample : Singleton<SceneControllerExample>
{
    void Awake()
    {
        base.Awake();
    }
}
