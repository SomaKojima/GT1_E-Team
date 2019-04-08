using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// データ一覧
/// </summary>
[CreateAssetMenu(menuName = "Original_PoopSheet")]
public class Date : ScriptableObject
{
    [Space(10), Tooltip("星と惑星の距離")]
    public float DIRECTION = 10.0f;

    [Tooltip("惑星の半径")]
    public float RADIUS = 5.0f;

    [Tooltip("星が落ちるまでの時間")]
    public float FALLTIME = 180.0f;

    [Header("◆それぞれの角速度")]

    [Tooltip("1フレームにX軸(もしくはZ軸)に進む角速度")]
    public float XZDEGREE = 1.0f;

    [Tooltip("1フレームにY軸に進む角速度")]
    public float YDEGREE = 0.05f;

    // ----------------------------------------------------------------

    [Header("◆明かりを灯す処理")]
    [Tooltip("明かりを灯す中点")]
    public Vector3 LightPos = new Vector3(0.0f, 5.5f, 0.0f);

    [Tooltip("明かりを灯す速さ")]
    public float SpeedSwitchOn = 0.1f;
}
