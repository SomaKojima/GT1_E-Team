using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camera;

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
        if(PlayerMove(out vel))
        {
            // 回転
            Quaternion inv = Quaternion.Inverse(this.transform.rotation);
            // カメラからプレイヤーまでのベクトル
            Vector3 vec = this.transform.position - camera.transform.position;
            // プレイヤーを原点としたローカル座標に変換
            vec = inv * vec;
            // Y軸の値をなくす
            vec.y = 0;
            // ワールド座標に戻す
            vec = this.transform.rotation * vec;
            // 移動方向とベクトルから回転を行う
            Vector3 vec_nomalize = vec.normalized;
            Vector3 vel_nomalize = vel.normalized;
            float cosine = Vector3.Dot(vec_nomalize, vel_nomalize);
            this.transform.rotation *= Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Acos(cosine), this.transform.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation *= Quaternion.AngleAxis(-3.0f, Vector3.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation *= Quaternion.AngleAxis(3.0f, Vector3.up);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vel">速度</param>
    /// <returns>移動していたならTrue</returns>
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
}
