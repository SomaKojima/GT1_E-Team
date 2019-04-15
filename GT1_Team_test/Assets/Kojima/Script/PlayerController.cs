﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;
    public GameObject planet;

    Rigidbody rigid;

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
    }

    private void FixedUpdate()
    {
        // 移動
        Vector3 vel = Vector3.zero;
        if(PlayerCameraMove(out vel))
        {
            // 速度の向き
            Vector3 dir = vel.normalized;
            // 回転
            PlayerRotation(dir);
        }
    }
    
    /// <summary>
    /// カメラ視点で移動する
    /// </summary>
    /// <param name="vel">速度</param>
    /// <returns>移動していたならTrue</returns>
    bool PlayerCameraMove(out Vector3 vel)
    {
        Vector3 dir = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) )
        {
            dir.y = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = Vector3.zero;
        }
        if(dir == Vector3.zero)
        {
            // 何もキーが押されていなければ関数を終わる
            vel = Vector3.zero;
            return false;
        }
        // 正規化
        dir = dir.normalized;
        // カメラ向きに合わせる
        dir = camera.transform.rotation * dir;
        // プレイヤーから惑星までのベクトル
        Vector3 vec = planet.transform.position - this.transform.position; 
        Vector3 vec_nomalize = vec.normalized;
        // 内積外積を用いて回転する("カメラの前方向" と "プレイヤーから惑星までのベクトル" を使用)
        float cosine = Vector3.Dot(camera.transform.forward, vec_nomalize);
        Vector3 axis = Vector3.Cross(camera.transform.forward, vec_nomalize);
        Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Acos(cosine), axis);
        //Quaternion q = Quaternion.FromToRotation(camera.transform.forward, vec_nomalize);
        dir = q * dir;

        // 速度を計算する
        vel = dir * speed;

        float dist = rigid.velocity.magnitude;
        if (dist < MaxSpeed)
        {
            rigid.AddForce(vel);
            return true;
        }
        return false;
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
        
        Debug.Log(angle);

        this.transform.rotation = this.transform.rotation * q;
    }
}
