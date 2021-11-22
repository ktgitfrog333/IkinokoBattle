using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの状態とアニメーションを制御するスクリプト
/// </summary>
public class PlayerStatus : MobStatus
{
    // TODO あとでプレイヤー向けにカスタムする
    public float Life { get { return _life; } }
}
