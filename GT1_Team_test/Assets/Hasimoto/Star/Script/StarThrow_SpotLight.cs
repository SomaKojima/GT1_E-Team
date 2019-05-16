using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarThrow_SpotLight : MonoBehaviour
{
    // スポットライトが光る最大時間
    [SerializeField, Header("スポットライトが光る最大時間")]
    private float maxTime = 5.0f;
    // エフェクトを描画してからの経過時間
    private float elapsedTime = 0.0f;

    void Update()
    {
        // エフェクトを描画する最大時間を超えた場合
        if (elapsedTime > maxTime)
        {
            // オブジェクトを破棄する
            Destroy(this.gameObject);
        }

        // 常に時間を計る
        elapsedTime += Time.deltaTime;

    }
}
