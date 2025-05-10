using UnityEngine;

public class SceneController25D : MonoBehaviour
{
    [field: SerializeField] public ChickenController25D ChickenController { get; private set; }

    void Update()
    {
        ChickenController.HandleUpdate();
    }
    

}
