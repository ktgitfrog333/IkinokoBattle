using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 動くオブジェクトの状態管理スクリプト
/// </summary>
public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal,
        Attack,
        Die
    }

    public bool IsMovable => StateEnum.Normal == _state;
    public bool IsAttackable => StateEnum.Normal == _state;
    public float LifeMax => lifeMax;

    [SerializeField] private float lifeMax = 10f;
    protected Animator _animator;
    protected StateEnum _state = StateEnum.Normal;
    public float _life { get; private set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _life = lifeMax;
        _animator = GetComponentInChildren<Animator>();
    }

    protected virtual void OnDie()
    {

    }

    public void Damage(int damage)
    {
        if (_state == StateEnum.Die)
        {
            return;
        }
        _life -= damage;
        if (_life > 0f)
        {
            return;
        }

        _state = StateEnum.Die;
        _animator.SetTrigger(AnimatorParameters.DIE);

        OnDie();
    }

    public void GoToAttackStateIfPossible()
    {
        if (IsAttackable == false)
        {
            return;
        }
        _state = StateEnum.Attack;
        _animator.SetTrigger(AnimatorParameters.ATTACK);
    }

    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die)
        {
            return;
        }
        _state = StateEnum.Normal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
