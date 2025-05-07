using UnityEngine;

public class CellVisibility : MonoBehaviour
{
    [field: SerializeField] public Material MaterialVisible { get; private set; }
    [field: SerializeField] public Material MaterialNotVisible { get; private set; }
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }

    public void SetVisible(bool isVisible)
    {
        if(isVisible)
        {
            MeshRenderer.material = MaterialVisible;
            return;
        }
        MeshRenderer.material = MaterialNotVisible;
    }
}
