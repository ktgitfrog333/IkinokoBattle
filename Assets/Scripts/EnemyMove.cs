using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class TagManager
{
    public static readonly string PLAYER = "Player";
}

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
/// <summary>
/// 目的地を指定するスクリプト
/// </summary>
public class EnemyMove : MonoBehaviour
{
    //[SerializeField] private PlayerController playerController;
    [SerializeField] private LayerMask raycastLayerMask;
    EnemyMoveCapsule _move;

    void Start()
    {
        _move = new EnemyMoveCapsule(gameObject);
    }

    //void Update()
    //{
    //    _move.MoveTarget(playerController.ctrl);
    //}

    public void OnDetectObject(Collider collider)
    {
        _move.MoveTargetTag(collider, TagManager.PLAYER, raycastLayerMask);
    }
}
