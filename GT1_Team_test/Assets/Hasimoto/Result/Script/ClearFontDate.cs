using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Clear文字専用のデータ
/// </summary>
public class ClearFontDate : MonoBehaviour
{
    // 生存時間
    private float timer = 0.0f;

    /// <summary>
    /// 取得・設定関数
    /// </summary>
    public float StateTimer { get { return timer; } set { timer = value; } }

}
