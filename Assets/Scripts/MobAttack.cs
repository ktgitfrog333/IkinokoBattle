using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
/// <summary>
/// 攻撃制御スクリプト
/// </summary>
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f;
    [SerializeField] private Collider attackCollider;
    private MobAttackCapsule _capsule;

    void Start()
    {
        _capsule = new MobAttackCapsule(gameObject);
    }

    public void OnAttackRangeEnter(Collider collider)
    {
        _capsule.AttackIfPossible();
    }

    public void OnAttackStart()
    {
        _capsule.EnabledCollier(attackCollider);
    }

    public void OnHitAttack(Collider collider)
    {
        _capsule.PostDamage(collider);
    }

    public void OnAttackFinished()
    {
        _capsule.DisabledCollier(attackCollider);
        _capsule.CooldownCoroutine(attackCooldown);
    }

    public void AttackIfPossible()
    {
        _capsule.AttackIfPossible();
    }
}
