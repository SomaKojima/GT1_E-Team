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

        [Header("プレイヤーのタグ名"), SerializeField]
        private string playerTag = "player";

        [Header("惑星のタグ名"), SerializeField]
        private string planetTag = "Planet";

        [Header("星のタグ名"), SerializeField]
        private string starTag = "dust";

        [Header("惑星の半径"),SerializeField]
        private float bigStarRadius = 62.5f;

        [Header("小さい星の半径"), SerializeField]
        private float smallStarRadius = 1.0f;

        [Header("現在、星と惑星の距離"), SerializeField]
        private float direction_Max = 90.0f;
        [SerializeField]
        private float direction_Miu = 90.0f;

        [Header("永遠に動き続ける星の数"), SerializeField]
        private int lifeTotal = 15;

        [Header("すぐに惑星に落ちる星の割合"), SerializeField, Range(0.0f, 1.0f)]
        private float starJustFallRatio = 0.5f;

        [Header("新しい星を作成する時間"), SerializeField]
        private float timeCreate_Max = 2.0f;
        [SerializeField]
        private float timeCreate_Miu = 2.0f;

        [Header("星が宇宙上に動く時間"), SerializeField]
        private float timeMove_Max = 5.0f;
        [SerializeField]
        private float timeMove_Miu = 5.0f;

        [Header("星が惑星上に落ちるまでの時間"), SerializeField]
        private float timeFall_Max = 3.0f;
        [SerializeField]
        private float timeFall_Miu = 3.0f;
        
        [Header("星が惑星上に滞在する時間"), SerializeField]
        private float timeState_Max = 10.0f;
        [SerializeField]
        private float timeState_Miu = 10.0f;

        [Header("◆それぞれの角速度")]
        [Header("1フレームにX軸(もしくはZ軸)に進む角速度"),SerializeField]
        private float degreeXZ_Max = 1.0f;
        [SerializeField]
        private float degreeXZ_Miu = 0.05f;

        [Header("1フレームにY軸に進む角速度"), SerializeField]
        private float degreeY_Max = 1.0f;
        [SerializeField]
        private float degreeY_Miu = 0.05f;

        // ----------------------------------------------------------------

        [Header("◆明かりを灯す処理")]
        [Tooltip("明かりを灯す中点"),SerializeField]
        private Vector3 lightPos = new Vector3(0.0f, 55.0f, 0.0f);

        [Tooltip("明かりを灯す速さ"),SerializeField]
        private float speedSwitchOn = 0.5f;

        // ----------------------------------------------------------------

        [Tooltip("星の効果音を鳴らすプレイヤーと星の距離"), SerializeField]
        private float sound_PlayerStarDirection = 15.0f;


    /// <summary>
    /// 取得関数
    /// </summary>

    // プレイヤーのタグ名
    public string PlayerTag { get { return playerTag; } private set { playerTag = value; } }

        // 惑星のタグ名
        public string PlanetTag { get { return planetTag; } private set { planetTag = value; } } 
        // 星のタグ名
        public string StarTag { get { return starTag; } private set { starTag = value; } }

        // 惑星の半径
        public float BigStarRadius { get { return bigStarRadius; } private set { bigStarRadius = value; } }
        // 小さい星の半径
        public float SmallStarRadius { get { return smallStarRadius; } private set { smallStarRadius = value; } }
    
        // 星と惑星の距離
        public float Direction_Max{ get { return direction_Max; } private set { direction_Max = value; } }
        public float Direction_Miu { get { return direction_Miu; } private set { direction_Miu = value; } }
           
        // 永遠に動き続ける星の数
        public int LifeTotal { get { return lifeTotal; } private set { lifeTotal = value; } }

        // すぐに惑星に落ちる星の割合
        public float StarJustFallRatio { get { return starJustFallRatio; } private set { starJustFallRatio = value; } }

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

        // ----------------------------------------------------------------

        // 星の効果音を鳴らすプレイヤーと星の距離
        public float Sound_PlayerStarDirection { get { return sound_PlayerStarDirection; } private set { sound_PlayerStarDirection = value; } }
}
