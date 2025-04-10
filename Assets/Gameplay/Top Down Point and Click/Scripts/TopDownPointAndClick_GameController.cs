using UnityEngine;

public partial class TopDownPointAndClick_GameController : MonoBehaviour
{
    [field: SerializeField] public Camera      Camera      { get; private set; }
    [field: SerializeField] public TopDownPointAndClick_CharacterController Player { get; private set; }
    [field: SerializeField] public LayerMask   LayerMask   { get; private set; }

    [SerializeField] private ClickData _clickData;

    void Update()
    {
        _clickData = ReadClickData(Input.mousePosition);

        // Resolve Click Data
        if (!Player.IsInteracting)
        {
            if (_clickData.Interactable != null)
            {
                _clickData.Interactable.Interact(Player);
            }
            else if (_clickData.WorldPosition != Vector3.negativeInfinity)
            {
                Player.Move(_clickData.WorldPosition);
            }
        }
    }

    ClickData ReadClickData(Vector2 screenPoint)
    {
        ClickData clickData     = new ClickData();
        clickData.WorldPosition = Vector3.negativeInfinity;

        if(!Input.GetMouseButtonDown(0))
            return clickData;

        Ray ray             = Camera.ScreenPointToRay(screenPoint);
        RaycastHit [] hits  = Physics.RaycastAll(ray, float.PositiveInfinity, LayerMask);

        if(hits.Length > 0)
            clickData.WorldPosition = hits[0].point;

        foreach (RaycastHit hit in hits)
        {
            if(hit.transform.TryGetComponent<TopDownPointAndClick_Interactable>(out TopDownPointAndClick_Interactable interactable))
                clickData.Interactable = interactable;
        }

        return clickData;
    }
}
