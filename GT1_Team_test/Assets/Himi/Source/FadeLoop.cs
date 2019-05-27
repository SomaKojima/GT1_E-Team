using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FadeLoop : MonoBehaviour
{
    private       SpriteRenderer m_spRenderer;       // スプライトレンダラー

    private const float          m_cycleBase = 1.0f; // 周期をずらすためのベース値
    public        float          m_cycleRate = 1.0f; // 周期をずらすための可変値

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        m_spRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // サインの値を取得
        double sin = Math.Sin(Time.time) * (m_cycleBase * m_cycleRate);

        // 色情報を取得
        var color = m_spRenderer.color;
        // フェード(-1～1)
        color.a = (float)sin;
        m_spRenderer.color = color;
    }
}
