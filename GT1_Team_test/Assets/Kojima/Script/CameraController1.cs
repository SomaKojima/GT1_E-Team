using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    /// <summary>
    /// カメラのターゲット    
    /// </summary>
    public GameObject target;

    public float angle = 30.0f;


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
        
    }

    private void FixedUpdate()
    {
        // 向きの更新
        Vector3 vec = this.transform.position - target.transform.position;
        Vector3 vecNormal = vec.normalized;


        // カメラの座標
        Vector3 pos = target.transform.position + startDistance;

        float cosine = Vector3.Dot(target.transform.up, -this.transform.forward);

        float size = Mathf.Cos(Mathf.Deg2Rad * angle);
        if (cosine < size &&
            cosine > -size)
        {
            //座標の更新
            this.transform.position = Vector3.Slerp(this.transform.position, pos, 0.1f);
        }

        Quaternion q = Quaternion.identity;
        q = Quaternion.FromToRotation(-this.transform.forward, vecNormal);
        q = q * this.transform.rotation;
        this.transform.rotation = q;
    }
}
