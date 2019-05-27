using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSet : MonoBehaviour
{
    private SpriteRenderer m_spRender;     // スプライトレンダラー

    public  Sprite         MainSprite;     // メインスプライト(表)
    public  Sprite         ReverseSprite;  // メインスプライト(裏)
    public  Sprite         ChengeSprite;   // 別のスプライトに差し替える用

    private SelectCursor   selectCursorCs; // SelectCursorスクリプト

    // Start is called before the first frame update
    void Start()
    {
        // SpriteRendererを取得
        m_spRender = gameObject.GetComponent<SpriteRenderer>();
        // メインスプライトに設定
        m_spRender.sprite = MainSprite;

        // SelectCursorスクリプトを取得
        selectCursorCs = gameObject.GetComponent<SelectCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        // 何もなかったらメインスプライトのまま
        m_spRender.sprite = MainSprite;
        // <START>にカーソルが接触していたらスプライトを変更する
        if (selectCursorCs.m_collideTag == "START")
        {
            m_spRender.sprite = ReverseSprite;
        }
    }
}
