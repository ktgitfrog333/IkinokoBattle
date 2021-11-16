using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveCapsule
{
    public NavMeshAgent _agent { get; private set; }
    public Transform _transform { get; private set; }
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    private EnemyStatus _status;

    public EnemyMoveCapsule(GameObject gameObject)
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _status = gameObject.GetComponent<EnemyStatus>();
        _transform = gameObject.transform;
    }

    public void MoveTarget(PlayerControllerCapsule ctrl)
    {
        _agent.destination = ctrl._transform.position;
    }

    public void MoveTargetTag(Collider collider, string tagName, LayerMask raycastLayerMask)
    {
        if (_status.IsMovable == false)
        {
            _agent.isStopped = true;
            return;
        }
        if (collider.CompareTag(tagName))
        {
            StopedEnemyAndSerchPlayer(collider, raycastLayerMask);
            _agent.destination = collider.transform.position;
        }
    }

    private void StopedEnemyAndSerchPlayer(Collider collider, LayerMask raycastLayerMask)
    {
        var posisionDiff = collider.transform.position - _transform.position;
        var distance = posisionDiff.magnitude;
        var direction = posisionDiff.normalized;
        var hitCount = Physics.RaycastNonAlloc(_transform.position, direction, _raycastHits, distance, raycastLayerMask);

        Debug.Log(DebugMessages.HIT_COUNT + hitCount);

        if (hitCount == 0)
        {
            _agent.isStopped = false;
            _agent.destination = collider.transform.position;
        }
        else
        {
            _agent.isStopped = true;
        }
    }
}
