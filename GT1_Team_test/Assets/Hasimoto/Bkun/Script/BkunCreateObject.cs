using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// B君の願いに叶うと、モデルが出現する
/// </summary>
public class BkunCreateObject : MonoBehaviour
{

    // B君の願いに叶わせるに必要になる星の数
    [SerializeField]
    private int starCount = 5;
    // 出現するモデル
    [Header("出現するモデル"), SerializeField]
    private GameObject obj_create;
    
    // プレイヤー
    private GameObject player;
    // プレイヤーがB君に話しかけられたか
    private bool IsSpeak = false;
    // 一度話しかけたか
    private bool IsOnce = false;

    void Start()
    {
        // プレイヤーのモデル
        player = GameObject.FindGameObjectWithTag("player");

        // モデルを非表示する
        obj_create.SetActive(false);
    }

    void Update()
    {
        // プレイヤーが持っている星の数
        int playercount = player.GetComponent<collision>().GetDustCount();

        if ((IsSpeak) && (playercount >= starCount))
        {
            // モデルを出現させる
            obj_create.SetActive(true);
        }
    }

    /// <summary>
    /// 取得・設定関数
    /// </summary>
    public bool IsPlayerSpeakBkun { get { return IsSpeak; } set { IsSpeak = value; } }

    // -----------------------------------------------------------------------------------------

    // テスト

    /// <summary>
    /// 当たり判定
    /// </summary>

    // オブジェクトが当たり続けている
    void OnTriggerStay(Collider col)
    {
        if ((col.tag == "player") && (Input.GetKeyDown(KeyCode.Z)))
        {
            
            // プレイヤーがB君に話しかけた状態にする
            IsSpeak = true;

            // 一度も話しかけていないか
            if (!IsOnce) IsOnce = true;     // 一度B君に話しかけた状態にする
            else IsSpeak = false;           // プレイヤーがB君に話しかけていない状態にする
        }
    }

    // オブジェクトに当たり終わった
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            Debug.Log("当たった");

            // プレイヤーがB君に話しかけていない
            IsSpeak = false;
            // 一度も話しかけていない状態に戻す
            IsOnce = false;
        }
    }
}