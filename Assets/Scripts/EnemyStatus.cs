using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
/// <summary>
/// 敵の状態管理スクリプト
/// </summary>
public class EnemyStatus : MobStatus
{
    EnemyStatusCapsule _capsule;
    protected override void Start()
    {
        base.Start();
        _capsule = new EnemyStatusCapsule(gameObject);
    }

    private void Update()
    {
        _capsule.PlayMotionWalk(_animator);
    }

    protected override void OnDie()
    {
        base.OnDie();
        _capsule.DestroyCoroutine(gameObject);
    }
}
