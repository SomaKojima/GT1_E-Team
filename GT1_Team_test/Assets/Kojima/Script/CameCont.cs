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
    
    public float max_distance = 5;

    public float offset_y = 10;

    Vector3 up = Vector3.forward;

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
        CameraRotation();
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
        localPos.y = offset_y;
        // ベクトルを計算
        Vector3 vec = -localPos;
        vec.y = 0;
        float length = vec.magnitude;
        Vector3 vec_normal = vec.normalized;

        // カメラの距離が遠い場合
        if (max_distance < length)
        {
            // 範囲の距離までの差分を計算
            float move_length = length - max_distance;
            // ターゲットに向けて移動量
            Vector3 move_vec = vec_normal * move_length;
            
            // ローカル座標をワールド座標に戻す
            Vector3 worldPos = target.transform.position + (target.transform.rotation * localPos);

            Vector3 pos = worldPos + (target.transform.rotation * move_vec);
            this.transform.position = Vector3.Slerp(this.transform.position, pos, 1.0f);
        }
    }


    void CameraRotation()
    {
        // ターゲットまでのベクトル
        Vector3 vec = target.transform.position - this.transform.position;
        // 惑星までのベクトル
        Vector3 vec2 = planet.transform.position - this.transform.position;
        // ターゲットまでのベクトルとカメラの上方向で軸を作成
        Vector3 axis = Vector3.Cross(vec, this.transform.up);
        // 惑星までのベクトルとaxisでカメラの上方向を作成
        Vector3 up = Vector3.Cross(axis, vec2);

        this.transform.LookAt(target.transform.position, up);
    }
}
