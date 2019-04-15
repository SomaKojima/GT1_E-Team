using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraMode
    {
        Nomal,
        Talk
    }
    /// <summary>
    /// カメラのターゲット    
    /// </summary>
    public GameObject player;
    // ターゲットが吸い寄せられている惑星
    public GameObject planet;

    // 話しかける時の位置
    public Transform talkPosition;
    // 話しかける相手
    public Transform talkTarget;

    // カメラのモード
    public CameraMode cameraMode = CameraMode.Nomal;
    // カメラとターゲットの最大距離
    public float max_distance = 5;
    // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    public float offset_y = 10;
    // カメラの上方向
    Vector3 up = Vector3.forward;

    // ノーマルカメラ
    NormalCamera normalCamera = new NormalCamera();
    // 話す用のカメラ
    TalkCamera talkCamera = new TalkCamera();


    // Start is called before the first frame update
    void Start()
    {
        // 通常カメラの設定
        normalCamera.Start(this.gameObject, player, planet);
        normalCamera.max_distance = max_distance;
        normalCamera.offset_y = offset_y;

        // 話す用のカメラの設定
        talkCamera.Start(this.gameObject, talkPosition, talkTarget, player);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        switch (cameraMode)
        {
            case CameraMode.Nomal:
                normalCamera.Update();
                break;
            case CameraMode.Talk:
                talkCamera.Update();
                break;
        }
    }

    /// <summary>
    /// 話す用カメラに変える
    /// </summary>
    /// <param name="talkChara">話す相手</param>
    /// <returns>変えられたかどうか</returns>
    public bool ChangeTalkMode(Transform talkChara, Transform cameraPos)
    {
        if (!talkChara) return false;
        cameraMode = CameraMode.Talk;
        talkTarget = talkChara;
        talkPosition = cameraPos;
        return true;
    }
}
