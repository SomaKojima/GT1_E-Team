using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ○○○君の願いに叶うと、モデルが出現する、もしくは消える
/// </summary>
public class CreateOrDeleteObject : MonoBehaviour
{
    // ○○○君の願いを叶わせるために必要になる星の数
    [Header("願いを叶わせるために必要になる星の数"), SerializeField]
    private int starCount = 0;
    // 出現する　もしくは 消える　
    [Header("チェック あり:モデルが出現する なし:モデルが消える"), SerializeField]
    private bool IsAppear;
    // 出現するもしくは消えるモデル
    [Header("出現する or 消える モデル"), SerializeField]
    private GameObject obj;

    // プレイヤー
    private GameObject player;
    // プレイヤーがB君に話しかけられたか
    private bool IsSpeak = false;
    // 一度話しかけたか
    private bool IsOnce = false;
    private bool IsClear = false;
    // お願い事を聞いたか
    private bool Iswish = false;


    void Start()
    {
        // プレイヤーのモデル
        player = GameObject.FindGameObjectWithTag("player");


        // 出現するモデル : 非表示する、消えるモデル   : 表示する
        obj.SetActive(!IsAppear);
    }

    void Update()
    {
        // プレイヤーが持っている星の数
        int playercount = player.GetComponent<collision>().GetDustCount();
        playercount = 100;
        if ((IsSpeak) && (playercount >= starCount)&&(Iswish))
        {
            // 出現するモデル : 表示する、 消えるモデル : 非表示する
            obj.SetActive(IsAppear);
            IsClear = true;
        }
    }

    /// <summary>
    /// 取得・設定関数
    /// </summary>
    public bool IsPlayerSpeakBkun { get { return IsSpeak; } set { IsSpeak = value; } }
    public bool IsWish { get { return Iswish; } set { Iswish = value; } }

    // -----------------------------------------------------------------------------------------

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
            else
            {
                IsSpeak = false;           // プレイヤーがB君に話しかけていない状態にする
                Iswish = true;               // お願いことを聞いた
            }
        }
    }
    // オブジェクトに当たり終わった
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            // プレイヤーがB君に話しかけていない
            IsSpeak = false;
             if(IsOnce) Iswish = true;
            // 一度も話しかけていない状態に戻す
            IsOnce = false;
        }
    }

    public int GetStarTarget()
    {
        return starCount;
    }

    public bool GetClearFlag()
    {
        return IsClear;
    }
    
    /// <summary>
    /// ○○○君の願いに叶うと、モデルが出現するもしくは消える
    /// </summary>
    public void Clear()
    {
        // 出現するモデル : 表示する、 消えるモデル : 非表示する
        obj.SetActive(IsAppear);
        // 願い事が叶った
        IsClear = true;
    }
}
