using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

enum TopDownPointAndClick_CharacterState
{
    Idle,
    Walking
}

public class TopDownPointAndClick_CharacterController : MonoBehaviour
{
    [field: SerializeField] public NavMeshAgent NavMeshAgent    { get; private set; }
    [field: SerializeField] public Animator Animator            { get; private set; }
    [field: SerializeField] public bool IsInteracting           { get; set; }

    void Update()
    {
        Animator.SetFloat("speed", NavMeshAgent.velocity.magnitude);
    }

    public void Move(Vector3 destination)
    {
        if(NavMeshAgent.isPathStale || NavMeshAgent.pathPending)
            NavMeshAgent.ResetPath();

        NavMeshAgent.SetDestination(destination);
    }

    public async Task MoveAsync(Vector3 destination)
    {
        Move(destination);

        while(NavMeshAgent.pathPending || NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
            await Task.Yield();
        
        while(NavMeshAgent.remainingDistance > NavMeshAgent.stoppingDistance + 0.1f)
        {
            if(NavMeshAgent.pathStatus == NavMeshPathStatus.PathInvalid || NavMeshAgent.isPathStale)
            break;
            await Task.Yield();
        }

        return;
    }

}
