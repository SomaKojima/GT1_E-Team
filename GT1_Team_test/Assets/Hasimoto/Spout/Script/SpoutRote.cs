using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 常に砂嵐が回転する
/// </summary>
public class SpoutRote : MonoBehaviour
{
    [SerializeField, Header("回転速度")]
    private float rotespeed = 1.0f;

   /// <summary>
   /// 更新処理
   /// </summary>
    void Update()
    {
        // 常に回転する
        transform.Rotate(new Vector3(0.0f, rotespeed, 0.0f));
    }
}
