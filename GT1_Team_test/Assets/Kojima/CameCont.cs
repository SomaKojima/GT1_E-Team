using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameCont : MonoBehaviour
{

    /// <summary>
    /// カメラのターゲット    
    /// </summary>
    public GameObject target;
    public GameObject planet;

    public float distance = 10;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // カメラの移動
        CameraMove();

        // カメラの向き
        Vector3 vec = this.transform.position - planet.transform.position;
        //Vector3 axis = Vector3.Cross(Vector3.Cross(Vector3.up, vec), Vector3.up);
        Vector3 axis = Quaternion.AngleAxis(target.transform.rotation.eulerAngles.x, Vector3.right)
            * Quaternion.AngleAxis(target.transform.rotation.eulerAngles.z, Vector3.forward) * Vector3.forward;
        this.transform.LookAt(target.transform.position, axis);
    }

    /// <summary>
    /// カメラの移動
    /// </summary>
    void CameraMove()
    {
        // ターゲットの逆回転
        Quaternion q = Quaternion.Inverse(target.transform.rotation);
        // カメラのローカル座標を計算（ターゲットを原点とした座標）
        Vector3 localPos = this.transform.position - target.transform.position;
        localPos = q * localPos;
        localPos.y = offset.y;
        // ベクトルを計算
        Vector3 vec = -localPos;
        float length = vec.magnitude;
        Vector3 vec_normal = vec.normalized;

        // カメラの距離が遠い場合
        if (distance < length)
        {
            // 範囲の距離までの差分を計算
            float move_length = length - distance;
            // ターゲットに向けて移動量
            Vector3 move_vec = vec_normal * move_length;

            //move_vec = target.transform.rotation * move_vec;



            // ローカル座標をワールド座標に戻す
            Vector3 worldPos = target.transform.position + (target.transform.rotation * localPos);

            Vector3 pos = worldPos + (target.transform.rotation * move_vec);
            this.transform.position = Vector3.Slerp(this.transform.position, pos, 1.0f);
        }
    }
}
