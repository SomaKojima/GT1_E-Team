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

    // 効果音を鳴らすか
    private bool IsSound = false;

    // 文字用の時間
    private float fonttime = 0.0f;

    // 効果音の時間
    private float soundtime = 0.0f;

    void Start()
    {
        // リザルトシーンのデータ
        date = GetComponent<ResultSceneDate>();
    }

    void Update()
    {
        if (!IsSound)
        {
            // クリアの文字がすべて表示され、なおかつキー操作がまだ有効ではない場合
            if ((date.IsClearFont_Appear) && (!(date.IsKey)))
            {
                // キー操作を有効するか
                if (fonttime >= date.KeyValidTime) date.IsKey = true;

                // 時間を計る
                fonttime++;
            }

            // 何かのキーで押された場合
            if ((Input.anyKeyDown) && (date.IsKey))
            {
                // 効果音を鳴らす
                IsSound = true;
                SoundManager.Instance.PlaySe("click");
            }
        }
        else
        {
            if(soundtime > 5)
            {
                // セレクトシーンに戻る
                SceneManager.LoadScene(date.SelectScene_Name);

            }


            // 時間を計る
            soundtime++;
        }
    }
}
