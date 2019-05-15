using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星が惑星に当たった時に描画するエフェクトによる処理
/// </summary>
public class StarEffect_HitPlanet : MonoBehaviour
{
    // エフェクトを描画する最大時間
    [SerializeField, Header("エフェクトを描画する最大時間")]
    private float maxTime = 3.0f;
    // エフェクトを描画してからの経過時間
    private float elapsedTime = 0.0f;

    
    void Update()
    {
        // エフェクトを描画する最大時間を超えた場合
        if(elapsedTime > maxTime)
        {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }
 
       // 常に時間を計る
       elapsedTime += Time.deltaTime;

    }

    /// <summary>
    /// 位置や向きを決める
    /// </summary>
    /// <param name="star">星</param>
    /// <param name="planet">惑星</param>
    public void DecideDirection(GameObject star,GameObject planet)
    {
        // 位置を決める
        transform.position = star.transform.position;

        // 惑星に対して正反対の向きを取得する
        Vector3 dic = transform.position - planet.transform.position;
        // 惑星に対して正反対の向きに回転する
        transform.localRotation = Quaternion.LookRotation(dic);
    }
}
