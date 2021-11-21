using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
/// <summary>
/// キャラクターを操作するスクリプト
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 3f;
    [SerializeField] private Animator _animator;
    private PlayerControllerCapsule ctrl;

    void Start()
    {
        ctrl = new PlayerControllerCapsule(gameObject);
    }

    void Update()
    {
        Debug.Log(ctrl._characterController.isGrounded ? DebugMessages.ON_THE_GROUND : DebugMessages.IN_THE_AIR);

        ctrl.SetMoveVelocity(CrossPlatformInputManager.GetAxis(InputManager.HORIZONTAL), CrossPlatformInputManager.GetAxis(InputManager.VERTICAL), moveSpeed);
        ctrl.SetActionAttack(CrossPlatformInputManager.GetButtonDown(InputManager.FIRE_1));
        //ctrl.LookAtObject();
        ctrl.MoveJumpOrGravity(Input.GetButtonDown(InputManager.JUMP), jumpPower);
        ctrl.PlayMotionWalk(_animator, AnimatorParameters.MOVE_SPEED);
    }
}
