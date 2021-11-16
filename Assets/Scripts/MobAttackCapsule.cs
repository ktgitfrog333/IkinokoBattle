using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MobAttackCapsule
{
    private MobStatus _status;

    public MobAttackCapsule(GameObject gameObject)
    {
        _status = gameObject.GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        if (_status.IsAttackable == true)
        {
            _status.GoToAttackStateIfPossible();
        }
    }

    public void EnabledCollier(Collider collider)
    {
        collider.enabled = true;
    }

    public void PostDamage(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null != targetMob)
        {
            targetMob.Damage(1);
        }
    }

    public void DisabledCollier(Collider collider)
    {
        collider.enabled = false;
    }

    public async void CooldownCoroutine(float attackCoolDown)
    {
        await Task.Delay((int)(attackCoolDown * 1000f));
        _status.GoToNormalStateIfPossible();
    }
}
