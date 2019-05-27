using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// クリアの文字が落下する
/// </summary>
public class FontFall : MonoBehaviour
{
    // リザルトシーンのデータ
    private ResultSceneDate date;
    // クリアの文字
    private GameObject[] clearFont;
    // クリアの文字数
    private int clearFont_total;

    void Start()
    {
        // クリアの文字
        clearFont = GameObject.FindGameObjectsWithTag("Result_ClearFont");

        // リザルトシーンのデータ
        date = GetComponent<ResultSceneDate>();

        // クリアの文字を非表示する
        foreach (GameObject obj in clearFont)
        {
            // 透明にする
            obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            // 文字を数える
            clearFont_total++;
        }
    }

    void Update()
    {
        // 文字(Clear)の番号
        int num = 1;
        foreach(GameObject obj in clearFont)
        {
            // 指定された文字が出現する
            Appear(obj, num);

            // 時間を計る
            obj.GetComponent<ClearFontDate>().StateTimer += Time.deltaTime;

            num++;
        }
    }

    /// <summary>
    /// 指定された文字が出現する
    /// </summary>
    /// <param name="obj">オブジェクト</param>
    /// <param name="num">番号</param>
    private void Appear(GameObject obj ,int num)
    {
        // 生存時間
        float statetime = obj.GetComponent<ClearFontDate>().StateTimer;
        // オブジェクトが出現する時間 
        float timeapeear = date.ClearFont_AppearTime * num;

        // 左から順に出現する
        if (statetime > timeapeear)
        {
            // 透明度
            float alpha = (statetime - timeapeear) * 0.4f;
 
            // 透明度の範囲   
            if (alpha > 1.0f) alpha = 1.0f;

            // すべての文字が完全に表示されたか
            if ((alpha > date.ClaerFont_FinalAlpha) && (num == clearFont_total))
            {
                date.IsClearFont_Appear = true;
            }

            // 透明度を設定する
            obj.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
    }
}
