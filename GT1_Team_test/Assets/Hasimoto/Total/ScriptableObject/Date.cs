using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// データ一覧
/// </summary>
[CreateAssetMenu(menuName = "Original_PoopSheet")]
public class Date : ScriptableObject
{
    [Tooltip("惑星の半径"),SerializeField]
    private float radius = 5.0f;

    [Space(10), Tooltip("星と惑星の距離"), SerializeField]
    private float direction_Max = 10.0f;
    [SerializeField]
    private float direction_Miu = 10.0f;

    [Tooltip("星が宇宙上に動く時間"), SerializeField]
    private float timeMove_Max = 0.0f;
    [SerializeField]
    private float timeMove_Miu = 0.0f;

    [Tooltip("星が惑星上に落ちるまでの時間"), SerializeField]
    private float timeFall_Max = 180.0f;
    [SerializeField]
    private float timeFall_Miu = 180.0f;

    [Tooltip("星が惑星上に滞在する時間"), SerializeField]
    private float timeState_Max = 10800.0f;
    [SerializeField]
    private float timeState_Miu = 10800.0f;

    [Header("◆それぞれの角速度")]
    [Tooltip("1フレームにX軸(もしくはZ軸)に進む角速度"),SerializeField]
    private float degreeXZ_Max = 5.0f;
    [SerializeField]
    private float degreeXZ_Miu = 1.0f;

    [Tooltip("1フレームにY軸に進む角速度")]
    public float degreeY_Max = 5.0f;
    [SerializeField]
    public float degreeY_Miu = 1.0f;

    // ----------------------------------------------------------------

    [Header("◆明かりを灯す処理")]
    [Tooltip("明かりを灯す中点"),SerializeField]
    public Vector3 LightPos = new Vector3(0.0f, 5.5f, 0.0f);

    [Tooltip("明かりを灯す速さ"),SerializeField]
    public float SpeedSwitchOn = 0.1f;

    
}
