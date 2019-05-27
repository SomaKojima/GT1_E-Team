using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// セレクトシーンに戻る
/// </summary>
public class SelectSceneChage : MonoBehaviour
{
    // リザルトシーンのデータ
    private ResultSceneDate date;

    // 時間
    private float time = 0.0f;

    void Start()
    {
        // リザルトシーンのデータ
        date = GetComponent<ResultSceneDate>();
    }

    void Update()
    {
        // クリアの文字がすべて表示され、なおかつキー操作がまだ有効ではない場合
        if((date.IsClearFont_Appear) && (!(date.IsKey)))
        {
            // キー操作を有効するか
            if (time >= date.KeyValidTime) date.IsKey = true;
            
            // 時間を計る
            time++;
        }
        
        // 何かのキーで押された場合
        if ((Input.anyKeyDown)&&(date.IsKey))
        {
            // セレクトシーンに戻る
            SceneManager.LoadScene(date.SelectScene_Name);
        }
    }
}
