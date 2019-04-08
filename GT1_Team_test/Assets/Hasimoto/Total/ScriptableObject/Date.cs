using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// データ一覧
/// </summary>
[CreateAssetMenu(menuName = "Original_PoopSheet")]
public class Date : ScriptableObject
{
    /// <summary>
    /// メンバー変数
    /// </summary>

        [Header("惑星の半径"),SerializeField]
        private float radius = 120.0f;

        [Header("現在、星と惑星の距離"), SerializeField]
        private float direction_Max = 180.0f;
        [SerializeField]
        private float direction_Miu = 180.0f;

        [Header("新しい星を作成する時間"), SerializeField]
        private float timeCreate_Max = 180.0f;
        private float timeCreate_Miu = 180.0f;

        [Header("星が宇宙上に動く時間"), SerializeField]
        private float timeMove_Max = 300.0f;
        [SerializeField]
        private float timeMove_Miu = 300.0f;

        [Header("星が惑星上に落ちるまでの時間"), SerializeField]
        private float timeFall_Max = 180.0f;
        [SerializeField]
        private float timeFall_Miu = 180.0f;
        
        [Header("星が惑星上に滞在する時間"), SerializeField]
        private float timeState_Max = 10800.0f;
        [SerializeField]
        private float timeState_Miu = 10800.0f;

        [Header("◆それぞれの角速度")]
        [Header("1フレームにX軸(もしくはZ軸)に進む角速度"),SerializeField]
        private float degreeXZ_Max = 5.0f;
        [SerializeField]
        private float degreeXZ_Miu = 1.0f;

        [Header("1フレームにY軸に進む角速度"), SerializeField]
        private float degreeY_Max = 5.0f;
        [SerializeField]
        private float degreeY_Miu = 1.0f;

                

        // ----------------------------------------------------------------

        [Header("◆明かりを灯す処理")]
        [Tooltip("明かりを灯す中点"),SerializeField]
        private Vector3 lightPos = new Vector3(33.0f, 55.0f, 0.0f);

        [Tooltip("明かりを灯す速さ"),SerializeField]
        private float speedSwitchOn = 0.5f;

    /// <summary>
    /// 取得関数
    /// </summary>

        // 惑星の半径
        public float Radius { get { return radius; } private set { radius = value; } }
        // 星と惑星の距離
        public float Direction_Max{ get { return direction_Max; } private set { direction_Max = value; } }
        public float Direction_Miu { get { return direction_Miu; } private set { direction_Miu = value; } }

        // 新しい星を作成する時間
        public float TimeCreate_Max { get { return timeCreate_Max; } private set { timeCreate_Max = value; } }
        public float TimeCreate_Miu { get { return timeCreate_Miu;  } private set { timeCreate_Miu = value; } }

        // 星が宇宙上に動く時間
        public float TimeMove_Max{ get { return timeMove_Max; } private set { timeMove_Max = value; } }
        public float TimeMove_Miu { get { return timeMove_Miu; } private set { timeMove_Miu = value; } }

        // 星が惑星上に落ちるまでの時間
        public float TimeFall_Max{ get { return timeFall_Max; } private set { timeFall_Max = value; } }
        public float TimeFall_Miu { get { return timeFall_Miu; } private set { timeFall_Miu = value; } }

        // 星が惑星上に滞在する時間
        public float TimeState_Max{ get { return timeState_Max; } private set { timeState_Max = value; } }
        public float TimeState_Miu { get { return timeState_Miu; } private set { timeState_Miu = value; } }

        // 1フレームにX軸(もしくはZ軸)に進む角速度
        public float DegreeXZ_Max{ get { return degreeXZ_Max; } private set { degreeXZ_Max = value; } }
        public float DegreeXZ_Miu { get { return degreeXZ_Miu; } private set { degreeXZ_Miu = value; } }

        // 1フレームにY軸に進む角速度
        public float DegreeY_Max { get { return degreeY_Max; } private set { degreeY_Max = value; } }
        public float DegreeY_Miu { get { return degreeY_Miu; } private set { degreeY_Miu = value; } }

        // --------------------------------------------------------------------------------------------------

        // 明かりを灯す中点
        public Vector3 LightPos { get { return lightPos; } private set{ lightPos = value; } }
        // 明かりを灯す速さ
        public float SpeedSwitchOn { get { return speedSwitchOn; } private set { speedSwitchOn = value; } }

}
