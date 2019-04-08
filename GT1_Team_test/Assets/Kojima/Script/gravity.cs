﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    List<GameObject> targetList = new List<GameObject>();       // 引力の発生する車
    public float accelerationScale; // 加速度の大きさ

    private void Start()
    {
    }

    void FixedUpdate()
    {
        foreach (GameObject target in targetList)
        {
            Rigidbody rigidbody = target.GetComponent<Rigidbody>();
            if (!rigidbody) continue;

            // 星に向かう向きの取得
            var direction = transform.position - target.transform.position;
            direction.Normalize();
            // 加速度与える
            rigidbody.AddForce((accelerationScale * direction), ForceMode.Acceleration);
        }

        // リストを初期化
        targetList.Clear();
    }
    
    private void OnTriggerStay(Collider other)
    {
        targetList.Add(other.gameObject);
    }
}
