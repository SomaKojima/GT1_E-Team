using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCursor : MonoBehaviour
{
    static  GameObject selectedGameObject; // 選択されたゲームオブジェクト
    private float      rayLength = 100.0f; // レイの長さ
    public  string     m_collideTag;       // カーソルと接触したオブジェクトのタグ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウスのレイを設定
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // ヒットするオブジェクト
        RaycastHit hit;
        // カーソルがオブジェクトに接触していたら
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // そのオブジェクトのタグを保存する
            m_collideTag = hit.collider.gameObject.tag;
        }
        else
        {
            // 接触しなかったら「null」を入れておく
            m_collideTag = "null";
        }
    }
}
