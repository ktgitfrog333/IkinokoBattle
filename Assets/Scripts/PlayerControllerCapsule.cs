using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// キャラクターを操作するスクリプト（裏側の処理）
/// </summary>
public class PlayerControllerCapsule
{
    public CharacterController _characterController { get; private set; }
    public Transform _transform { get; private set; }
    private Vector3 _moveVelocity;
    private PlayerStatus _status;
    private MobAttack _attack;

    public PlayerControllerCapsule(GameObject gameObject)
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _transform = gameObject.transform;
        //_moveVelocity = new Vector3();
        _status = gameObject.GetComponent<PlayerStatus>();
        _attack = gameObject.GetComponent<MobAttack>();
    }

    public void SetMoveVelocity(float horizontal, float vertical, float speed)
    {
        if (_status.IsMovable == true)
        {
            _moveVelocity.x = horizontal * speed;
            _moveVelocity.z = vertical * speed;

            LookAtObject();
        }
        else
        {
            _moveVelocity.x = 0f;
            _moveVelocity.z = 0f;
        }
    }

    public void SetActionAttack(bool fire1)
    {
        _attack.AttackIfPossible();
    }

    private void LookAtObject()
    {
        _transform.LookAt(_transform.position + new Vector3(_moveVelocity.x, 0f, _moveVelocity.z));
    }

    public void MoveJumpOrGravity(bool jump, float jumpPoer)
    {
        if (IsGrounded() == true)
        {
            if (jump == true)
            {
                Debug.Log(DebugMessages.JUMP);
                _moveVelocity.y = jumpPoer;
            }
        }
        else
        {
            _moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }

        _characterController.Move(_moveVelocity * Time.deltaTime);
    }

    public void PlayMotionWalk(Animator animator, string parameter)
    {
        animator.SetFloat(parameter, new Vector3(_moveVelocity.x, 0f, _moveVelocity.z).magnitude);
    }

    private bool IsGrounded()
    {
        var ray = new Ray(_transform.position + new Vector3(0f, 0.1f), Vector3.down);
        var raycastHits = new RaycastHit[1];
        var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
        return hitCount >= 1f;
    }
}
