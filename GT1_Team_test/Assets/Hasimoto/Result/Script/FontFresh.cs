using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontFresh : MonoBehaviour
{
    // 「Please Any Key」の文字
    public GameObject PleaseAnyKeyImage;

    // リザルトシーンのデータ
    private ResultSceneDate date;
    
    // 時間
    private float time = 0.0f;
    // 初めて文字を表示する
    private bool IsFirstAppear = false;

    void Start()
    {
        // リザルトシーンのデータ
        date = GetComponent<ResultSceneDate>();

        // 文字を非表示する
        PleaseAnyKeyImage.SetActive(false);
    }

    void Update()
    {
        // キー操作が有効ではない場合、何もしない
        if (!(date.IsKey)) return;

        // 文字を表示する
        if (!(IsFirstAppear)) { PleaseAnyKeyImage.SetActive(true); IsFirstAppear = true; }

        // 時間を計る
        time += Time.deltaTime;

        // オブジェクトが時間ごとに表示、非表示する
        if (time >= date.PleaseanykeyFont_FreshTime)
        {
            // 表示、非表示する
            PleaseAnyKeyImage.SetActive(!(PleaseAnyKeyImage.activeInHierarchy));
            // 時間をリセットする
            time = 0.0f;
        }
        
    }
}