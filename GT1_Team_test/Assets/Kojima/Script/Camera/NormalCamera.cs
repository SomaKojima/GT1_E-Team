﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCamera
{
    public GameObject camera;
    // カメラのターゲット    
    public GameObject player;
    // ターゲットが吸い寄せられている惑星
    public GameObject planet;

    // カメラとターゲットの最大距離
    public float max_distance = 5;
    // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    public float offset_y = 10;
    // カメラの上方向
    Vector3 up = Vector3.forward;

    // Start is called before the first frame update
    public void Start(GameObject _camera, GameObject _player, GameObject _planet)
    {
        camera = _camera;
        player = _player;
        planet = _planet;
    }

    // Update is called once per frame
    public void Update()
    {
        NormalCameraMove();
        NormalCameraRotation();
    }

    /// <summary>
    /// 通常カメラの移動
    /// </summary>
    void NormalCameraMove()
    {
        // 惑星からプレイヤーまでの回転(ワールド座標に戻す用)
        Quaternion q = Quaternion.FromToRotation(Vector3.up, (player.transform.position - planet.transform.position).normalized);
        // 逆回転(ローカル座標に戻す用)
        Quaternion inv = Quaternion.Inverse(q);
        // カメラのローカル座標を計算
        Vector3 localPos = camera.transform.position - player.transform.position;
        localPos = inv * localPos;
        // Y軸は固定（高さは固定）
        localPos.y = offset_y;
        // ベクトルを計算
        Vector3 vec = -localPos;
        // Y軸の動きをなくす
        vec.y = 0;
        float length = vec.magnitude;
        Vector3 vec_normal = vec.normalized;
        
        Vector3 move_vec = Vector3.zero;

        // カメラの距離が遠い場合
        if (max_distance < length)
        {
            // 範囲の距離までの差分を計算
            float move_length = length - max_distance;
            // ターゲットに向けて移動量
            move_vec = vec_normal * move_length;
        }

        // ローカル座標をワールド座標に戻す
        Vector3 worldPos = player.transform.position + (q * localPos);

        Vector3 pos = worldPos + (q * move_vec);
        camera.transform.position = Vector3.Slerp(camera.transform.position, pos, 0.05f);
    }

    /// <summary>
    /// 通常カメラの回転
    /// </summary>
    void NormalCameraRotation()
    {
        // ターゲットまでのベクトル
        Vector3 vec = player.transform.position - camera.transform.position;
        // 惑星までのベクトル
        Vector3 vec2 = planet.transform.position - camera.transform.position;
        // ターゲットまでのベクトルとカメラの上方向で軸を作成
        Vector3 axis = Vector3.Cross(vec, camera.transform.up);
        // 惑星までのベクトルとaxisでカメラの上方向を作成
        Vector3 up = Vector3.Cross(axis, vec2);

        camera.transform.LookAt(player.transform.position, up);
    }

}
