using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// B君の願いに叶うと、木のモデルが生える
/// </summary>
public class BkunCreateTree : MonoBehaviour
{

    // B君の願いに叶わせるに必要になる星の数
    [SerializeField]
    private int starCount = 5;
    // プレイヤー
    private GameObject player;
    // 木のモデル
    private GameObject bigtree;
    // プレイヤーがB君に話しかけられたか
    private bool IsSpeak = false;
    // 一度話しかけたか
    private bool IsOnce = false;

    void Start()
    {
        // プレイヤーのモデル
        player = GameObject.FindGameObjectWithTag("player");

        // 木のモデルを呼ぶ
        foreach (Transform child in transform)
        {
            if (child.tag == "Tree")
            {
                // 木のモデルを保存する
                bigtree = child.gameObject;
                // 木のモデルを非表示する
                bigtree.SetActive(false);
                break;
            }
        }
    }

    void Update()
    {

        // プレイヤーが持っている星の数
        int playercount = player.GetComponent<collision>().GetDustCount();

        if ((IsSpeak) && (playercount >= starCount))
        {
            // 木のモデルを出現させる
            bigtree.SetActive(true);
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