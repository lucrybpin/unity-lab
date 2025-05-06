using UnityEngine;
using UnityEngine.UI;

public class CellView : MonoBehaviour
{
    [field: SerializeField] public int X    { get; private set; }
    [field: SerializeField] public int Y    { get; private set; }
    [field: SerializeField] public bool IsObstacle { get; set; }
    [field: SerializeField] public Image Image { get; private set; }

    void Awake()
    {
        Image = GetComponent<Image>();

        if(IsObstacle)
            SetObstacle();
    }

    [ContextMenu("SetupName")]
    public void SetupName()
    {
        gameObject.name = $"cell ({X},{Y})";
    }

    public void SetPlayer()
    {
        Image.color = Color.green;
    }

    public void SetObstacle()
    {
        IsObstacle = true;
        Image.color = Color.black;
    }

    public void SetVisible(bool visible)
    {
        if(visible)
            Image.color = Color.blue;
        else
            Image.color = Color.gray;
    }

    public void Clear()
    {
        Image.color = Color.white;
    }

}
