using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCameraMove : MonoBehaviour
{
    // カメラとターゲットの最大距離
    [SerializeField]
    private float max_distance = 5;
    // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    [SerializeField]
    private float offset_y = 10;

    // ノーマルカメラ
    private NormalCamera normalCamera = new NormalCamera();


    void Start()
    {
        // プレイヤー
        GameObject player = GameObject.FindGameObjectWithTag("player");

        // プラネット
        GameObject planet = GameObject.FindGameObjectWithTag("Planet");

        // 通常カメラの設定
        normalCamera.Start(this.gameObject, player, planet);        // 初期設定
        normalCamera.max_distance = max_distance;                   // カメラとターゲットの最大距離
        normalCamera.offset_y = offset_y;                           // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    }

    // Update is called once per frame
    void Update()
    {
        // 常にノーマルのカメラで画面を映す
        normalCamera.Update();
    }
}
