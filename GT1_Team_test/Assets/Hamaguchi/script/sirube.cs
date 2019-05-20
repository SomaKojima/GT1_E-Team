using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirube : MonoBehaviour
{
    public enum PlayerMode
    {
        Normal,
        Talk
    };

    public GameObject planet;
    public collision col;

    Rigidbody rigid;
    PlayerMode mode;

    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float MaxSpeed = 5.0f;

    [SerializeField]
    float rotation_speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (col.GetTalkFlag())
        {
            mode = PlayerMode.Talk;


            // 話す用のカメラの設定
            Transform pos = null;
            // 子オブジェクトを全て取得する
            foreach (Transform childTransform in col.GetTarget().transform.parent.transform)
            {
            }
        }
        else
        {
            mode = PlayerMode.Normal;
        }
        switch (mode)
        {
            case PlayerMode.Normal:
                NormalModeUpdate();
                break;
            case PlayerMode.Talk:
                break;
        }
    }

    private void FixedUpdate()
    {

    }

    // 通常のモードの更新処理
    private void NormalModeUpdate()
    {
        // 移動
        Vector3 vel = Vector3.zero;
        
    }


    /// <summary>
    /// プレイヤー視点で移動する
    /// </summary>
    /// <param name="vel"></param>
    /// <returns></returns>
    bool PlayerMove(out Vector3 vel)
    {
        vel = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            vel.z = speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            vel.z = -speed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = Vector3.zero;
        }
        else
        {
            // 何もキーが押されていなければ関数を終わる
            return false;
        }
        vel = this.transform.rotation * vel;

        float dist = rigid.velocity.magnitude;
        if (dist < MaxSpeed)
        {
            rigid.AddForce(vel);
            return true;
        }
        return false;
    }


    /// <summary>
    /// プレイヤーの回転
    /// </summary>
    /// <param name="dir">dirの向きに回転</param>
    void PlayerRotation(Vector3 dir)
    {
        if (dir == Vector3.zero) return;
        Quaternion q = Quaternion.identity;

        // 角度を求める
        float cosine = Vector3.Dot(dir, this.transform.forward);

        // 向いている向きと進む向きが同じ場合は何もしない
        if (cosine > 0.99f) return;

        float radian = Mathf.Acos(cosine);
        float angle = Mathf.Rad2Deg * radian;

        // 時計回りの回転
        q = Quaternion.AngleAxis(angle, Vector3.up);
        // 反時計回転をする時（左回転）軸を変えて計算をし直す
        if (Vector3.Dot(dir, this.transform.right) < 0)
        {
            q = Quaternion.AngleAxis(angle, Vector3.down);
        }

        this.transform.rotation = this.transform.rotation * q;
    }

    public PlayerMode Mode
    {
        get { return mode; }
        set { mode = value; }
    }
}