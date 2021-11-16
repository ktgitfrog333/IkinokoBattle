using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class EnemyStatusCapsule
{
    private NavMeshAgent _agent;
    public EnemyStatusCapsule(GameObject gameObject)
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void PlayMotionWalk(Animator animator)
    {
        animator.SetFloat(AnimatorParameters.MOVE_SPEED, _agent.velocity.magnitude);
    }

    public async void DestroyCoroutine(GameObject gameObject)
    {
        await Task.Delay(3000);
        Object.Destroy(gameObject);
    }
}
