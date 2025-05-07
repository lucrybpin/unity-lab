using UnityEngine;

public class CellView3D : MonoBehaviour
{
    [field: SerializeField] public Vector2 GridPosition { get; set; }
    [field: SerializeField] public bool IsObstacle      { get; set; }

    [ContextMenu("Convert")]
    public void Convert()
    {
        transform.name = $"Block {GridPosition.x},{GridPosition.y}";
    }
}
