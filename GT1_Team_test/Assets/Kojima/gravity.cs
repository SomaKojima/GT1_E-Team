using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    public GameObject target;       // 引力の発生する車
    public float accelerationScale; // 加速度の大きさ

    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = target.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // 星に向かう向きの取得
        var direction = transform.position - target.transform.position;
        direction.Normalize();

      

        // 加速度与える
        rigidbody.AddForce((accelerationScale * direction), ForceMode.Acceleration);
        
    }
}
