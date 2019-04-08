using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  < 値を変える目安 >
 *   ○ … 最初のみ値を変える
 *   ◇ … 最初から最後まで値を変える
 *   □ … 途中から値を変える
 */

/// <summary>
/// 星のデータ
/// </summary>
public class StarDate : MonoBehaviour
{
    /// <summary>
    /// メンバー変数
    /// </summary>

        // ○星と惑星の距離
        [SerializeField] private float direction = 0.0f;
        // ◇現在の星と惑星の距離
        [SerializeField] private float radius = 0.0f;
        // ○1フレームに縮む半径の長さ
        [SerializeField] private float radiusShrinkage = 0.0f;

        // ○星が宇宙上に動く時間
        [SerializeField] private float timeMove = 0.0f;
        // ○星が宇宙から惑星に落ちる時間
        [SerializeField] private float timeFalling = 0.0f;
        // ○星が惑星上に滞在する時間
        [SerializeField] private float timeState = 0.0f;
        // □星の生存時間
        [SerializeField] private float time = 0.0f;

        // ○1フレームにX軸(もしくはZ軸)に進む角速度
        [SerializeField] private float angularVelocity_DegreeXZ = 0.0f;
        // ○1フレームにY軸に進む角速度
        [SerializeField] private float angularVelocity_DegreeY = 0.0f;
        // ◇現在X軸(もしくはZ軸)による角度
        [SerializeField] private float degreeXZ = 0.0f;
        // ◇現在Y軸による角度
        [SerializeField] private float degreeY = 0.0f;

    /// <summary>
    /// 取得・設定関数
    /// </summary>

        // ○星と惑星の距離
        public float Direction       { get { return direction;       } set { direction = value;       } }
        // ◇現在の星と惑星の距離
        public float Radius          { get { return radius;          } set { radius = value;          } }
        // ○1フレームに縮む半径の長さ
        public float RadiusShrinkage { get { return radiusShrinkage; } set { radiusShrinkage = value; } }

        // ○星が宇宙上に動く時間
        public float TimeMove       { get { return timeMove;    } set { timeMove = value;      } }
        // ○星が宇宙から惑星に落ちる時間
        public float TimeFalling     { get { return timeFalling; } set { timeFalling = value;   } }
        // ○星が惑星上に滞在する時間
        public float TimeState       { get { return timeState;   } set { timeState = value;     } }
        // □星の生存時間
        public float Time            { get { return time;        } set { time = value;          } }
        
        // ○1フレームにX軸(もしくはZ軸)に進む角速度
        public float AngularVelocity_DegreeXZ   { get { return angularVelocity_DegreeXZ; } set { angularVelocity_DegreeXZ = value;  } }
        // ○1フレームにY軸に進む角速度
        public float AngularVelocity_DegreeY    { get { return angularVelocity_DegreeY;  } set { angularVelocity_DegreeY = value;   } }
        // ◇現在X軸(もしくはZ軸)による角度
        public float DegreeXZ                   { get { return degreeXZ;  }                set { degreeXZ = value;  } }
        // ◇現在Y軸による角度
        public float DegreeY                    { get { return degreeY;   }                set { degreeY = value;   } }

}