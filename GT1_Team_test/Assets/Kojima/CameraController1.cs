using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    // カメラのターゲット
    public GameObject target;

    // ターゲット（初期位置）からカメラ（初期位置）までの距離
    Vector3 startDistance;


    // Start is called before the first frame update
    void Start()
    {
        startDistance = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // カメラの座標
        Vector3 pos = target.transform.position + (target.transform.rotation * startDistance);

        //座標の更新
        this.transform.position = pos;

        // カメラの向きを変える
        this.transform.LookAt(target.transform.position);
    }
}
