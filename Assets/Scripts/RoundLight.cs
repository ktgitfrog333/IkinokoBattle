using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundLight : MonoBehaviour
{
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // 1フレーム（フレーム時間の差異調整込み）ごとにクォータニオン角度Yを調整する
        _transform.Rotate(new Vector3(0f, -12f) * Time.deltaTime);
    }
}
