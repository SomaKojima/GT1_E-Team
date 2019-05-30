using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllManager : MonoBehaviour
{
    public enum CameraMode
    {
        Start,
        Nomal,
        Talk,
        Goal
    }
    /// <summary>
    /// カメラのターゲット    
    /// </summary>
    public GameObject player;
    // ターゲットが吸い寄せられている惑星
    public GameObject planet;
    // カメラのモード
    public CameraMode cameraMode = CameraMode.Nomal;
    // カメラとターゲットの最大距離
    public float max_distance = 5;
    // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    public float offset_y = 10;
    // 開始時の追いかける相手
    public List<GameObject> targets = new List<GameObject>();

    // ゴール時の座標
    public GameObject GoalTargetPos;
    public GameObject panel;
    public float interval;

    // プレイヤーの状態を取得するためプレイヤーのコントローラー
    PlayerController playerController;

    // カメラの上方向
    Vector3 up = Vector3.forward;

    // ノーマルカメラ
    NormalCamera normalCamera = new NormalCamera();
    // 話す用のカメラ
    TalkCamera talkCamera = new TalkCamera();
    // 開始用のカメラ
    StartCamera startCamera = new StartCamera();
    // ゴール時のカメラ
    GoalCamera goalCamera = new GoalCamera();

    // Start is called before the first frame update
    void Start()
    {
        // 通常カメラの設定
        normalCamera.Start(this.gameObject, player, planet);
        normalCamera.max_distance = max_distance;
        normalCamera.offset_y = offset_y;

        // 開始カメラの設定
        startCamera.max_distance = max_distance;
        startCamera.offset_y = offset_y;
        startCamera.targets = targets;
        startCamera.Start(this.gameObject, planet, player);

        // ゴールカメラの設定
        goalCamera.max_distance = max_distance;
        goalCamera.offset_y = offset_y;
        goalCamera.interval = interval;
        goalCamera.panel = panel;
        goalCamera.Start(this.gameObject, planet, GoalTargetPos);
        
        // プレイヤーのコンポーネントを取得
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        // ハシモト------------------------------------------------------------------
        // ミニマップを表示もしくは非表示を決めるフラグ
        bool minimappflag = false;
        
        //---------------------------------------------------------------------------


        if (cameraMode == CameraMode.Start)
        {
            startCamera.Update();
        }
        else
        {
            switch (playerController.Mode)
            {
                case PlayerController.PlayerMode.Normal:
                    normalCamera.Update();
                    // ハシモト------------------------------------------------------------------
                    // ミニマップを表示する
                    minimappflag = true;
                    //---------------------------------------------------------------------------

                    break;
                case PlayerController.PlayerMode.Talk:
                    talkCamera.Update();
                    break;
                case PlayerController.PlayerMode.Clear:
                    goalCamera.Update();
                    break;
            }
        }

        // ハシモト------------------------------------------------------------------
        // ミニマップのカメラの位置と向きをメインカメラ
        GameObject.Find("SmallCamera").GetComponent<SmallCameraMove>().FitMainCamera(gameObject, minimappflag);
        //---------------------------------------------------------------------------

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

        talkCamera.Start(this.gameObject, cameraPos, talkChara, player);
        return true;
    }
}
