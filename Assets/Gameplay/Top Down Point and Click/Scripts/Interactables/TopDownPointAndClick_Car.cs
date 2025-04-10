using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class TopDownPointAndClick_Car : MonoBehaviour, TopDownPointAndClick_Interactable
{
    [field: SerializeField] public Transform InteractTransform { get; private set; }
    public async Task Interact(TopDownPointAndClick_CharacterController interactor)
    {
        interactor.IsInteracting = true;
        await interactor.MoveAsync(InteractTransform.position);
        await transform.DOShakeScale(.52f, 0.25f, 10).SetEase(Ease.OutBounce).AsyncWaitForCompletion();
        interactor.IsInteracting = false;
    }
}
