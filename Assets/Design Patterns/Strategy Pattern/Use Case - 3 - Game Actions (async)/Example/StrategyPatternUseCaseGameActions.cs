using System.Threading.Tasks;
using UnityEngine;

public class StrategyPatternUseCaseGameActions : MonoBehaviour
{
    async Task Start()
    {
        GameObject actor;
        actor = gameObject;

        // current strategy
        IGameAction gameAction;

        // Switch strategy
        gameAction = new MoveAction();
        await gameAction.Execute(actor);

        // Switch strategy
        gameAction = new ChangeColorAction();
        await gameAction.Execute(actor);

        // Switch strategy
        gameAction = new RotateAction();
        await gameAction.Execute(actor);

        // Switch strategy
        gameAction = new TeleportAction(new Vector3(7, 1, 0));
        await gameAction.Execute(actor);
        
    }
}
