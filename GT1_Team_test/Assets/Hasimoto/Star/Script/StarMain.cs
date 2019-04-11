using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 名前を省略
using Kind = StarDate.Kind;

/// <summary>
/// 星の中心
/// </summary>
public class StarMain : MonoBehaviour
{ 
        
    // 惑星
    private GameObject planet;
    [Tooltip("星")]
    public GameObject starPrefab;
    [Tooltip("データ")]
    public Date _Date;

    // 星による関数
    private StarFunction starfuc;
    // 星のデータ
    private StarDate starDate;

    // 新しい星を作成する時間
    private float timecreate = 0.0f;

    // 現在のフレーム
    private float frame = 0.0f;

    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag(_Date.PlanetTag);

        // 新しい星を作成する時間
        timecreate = Random.Range(_Date.TimeCreate_Miu, _Date.TimeCreate_Max);

        // すぐに星を作成するように現在のフレームをずらす
        frame = timecreate;

        // 永遠に残す星を作成する
        int total = _Date.LifeTotal;
        for(int i = 0 ; i < total; i++)
        {
            Create(Kind.ALWAYSMOVE);
        }
    }

    void Update()
    {
        // 時間ごとに星を新しく作成する
        if (frame == timecreate)
        {
            // 割合
            float ratio = Random.Range(0.0f, 1.0f);
            // すぐに惑星上に落ちる星の割合
            float rationstarfall = _Date.StarJustFallRatio;

            if (ratio <= rationstarfall)
            {
                // すぐに惑星上に落ちる星を新しく作成する
                Create(Kind.JUSTFALL);
            }
            else
            {
                // 惑星に回って落ちる星を新しく作成する
                Create(Kind.MOVEANDFALL);
            }

            // 改めて新しい星を作成する時間を決める
            timecreate = Random.Range(_Date.TimeCreate_Miu, _Date.TimeCreate_Max);
            
            // 時間をリセットする
            frame = 0.0f;
        }

        // 複数の星を呼ぶ
        foreach (GameObject star in GameObject.FindGameObjectsWithTag(_Date.StarTag))
        {
            // 星のデータ
            StarDate starDate = star.GetComponent<StarDate>();

            // 惑星の穴の奥まで進まない場合
            if (!starDate.IsFallHole)
            {
                // 星の生存時間
                float startime = starDate.Time;

                // 星が宇宙上に動く時間
                float timeMove = starDate.TimeMove;
                // 星が宇宙上に動き始めてから惑星上に落ちるまでの時間
                float timeMoveFalling = timeMove + starDate.TimeFalling;
                // 星が宇宙上に動き始めてから惑星上に生存するまでの時間
                float timeMoveState = timeMoveFalling + starDate.TimeState;

                // 星が宇宙上に動き始めてから惑星上に落ちるまで もしくは 永遠に消えない星
                if (((starDate.StarKind == Kind.MOVEANDFALL) && (startime < timeMoveFalling)) ||
                     (starDate.StarKind == Kind.ALWAYSMOVE))
                {
                    // 円に沿って星が動く
                    ParallelToCircle(star);

                    // 星が落ち始める準備 かつ 今後消える星
                    if ((startime >= timeMove) && (starDate.StarKind == Kind.MOVEANDFALL))
                    {
                        // 星が軌道する半径を縮む
                        starDate.Range -= starDate.RadiusShrinkage;
                    }
                }
                else
                // すぐに惑星上に落ちる星
                if (starDate.StarKind == Kind.JUSTFALL)
                {
                    // 星と惑星の距離
                    Vector3 range = star.transform.position - planet.transform.position;
                    // 星と惑星の長さ
                    float length = range.magnitude;
                    // 惑星の半径の長さ
                    float radius = _Date.BigStarRadius;

                    if (length > radius)
                    {
                        // 距離を正規化する
                        range.Normalize();
                        // 移動する
                        star.transform.position += -range;
                    }
                    else
                    {
                        // 星が穴に落ちて消すか判断する
                        FallHoleAndDestory(star);
                    }
                }

                // 星が穴に落ちて消すか判断する
                if (((startime > timeMoveFalling) && (starDate.StarKind == Kind.MOVEANDFALL)))
                {
                    FallHoleAndDestory(star);
                }

                // 星を消す
                if ((startime > timeMoveState) && ((starDate.StarKind == Kind.MOVEANDFALL) || (starDate.StarKind == Kind.MOVEANDFALL)))
                {
                    Destroy(star);
                }
                else
                {
                    // 星の生存時間を計る
                    starDate.Time++;

                    // ------------------------------------------------------------------------------------
                    
                    // 光を探す
                    foreach(Transform child in star.transform)
                    {
                        Light light = child.GetComponent<Light>();
                        // 光の向き
                        if (light != null)
                        {
                            // 星と惑星の距離
                            Vector3 rage = planet.transform.position - star.transform.position;
                            Quaternion look = Quaternion.LookRotation(rage);
                            // 回転する
                            star.transform.localRotation = look;
                        }

                    }

                  }
            }
            else
            // 小さい星が惑星の穴の奥まで進む
            {
                // 星と惑星の距離
                Vector3 range =  planet.transform.position- star.transform.position;
                range.Normalize();

                // 長さ
                float length = (_Date.SmallStarRadius * 2) * 2;

                // 小さい星が進む
                star.transform.position += range;

                // レイが当たったオブジェクトの情報
                RaycastHit hit;

                // レイとオブジェクトの当たり判定
                if (Physics.Raycast(new Ray(star.transform.position, range), out hit, length))
                {
                    Destroy(star);
                }
            }
        }
        // フレームを計る
        frame++;
    }

    /// <summary>
    /// 星を作成する
    /// </summary>
    private void Create(Kind starkind)
    {
        // 星を新しく作成する
        GameObject newstar = Instantiate(starPrefab) as GameObject;

        // --------------------------------------------------------------------------------------------
        // 星のデータ
        StarDate starDate = newstar.GetComponent<StarDate>();

        // 星の種類
        starDate.StarKind = starkind;

        // 回って落ちる星
        if (starkind == Kind.MOVEANDFALL)
        {
            // 星が宇宙上に動く時間
            starDate.TimeMove = Random.Range(_Date.TimeMove_Miu, _Date.TimeMove_Max);
            // 星が宇宙から惑星に落ちる時間
            starDate.TimeFalling = Random.Range(_Date.TimeFall_Miu, _Date.TimeFall_Max);
        }

        // 回って落ちる星　もしくは すぐに落ちる星
        if(starkind == Kind.MOVEANDFALL || starkind == Kind.JUSTFALL)
        {
            // 星が惑星上に滞在する時間
            starDate.TimeState = Random.Range(_Date.TimeState_Miu, _Date.TimeState_Miu);
        }
        // 星と惑星の距離 と 現在の星と惑星の距離
        starDate.Direction = starDate.Range = Random.Range(_Date.Direction_Miu, _Date.Direction_Max);
        // 1フレームに縮む半径の長さを求める
        starDate.RadiusShrinkage = (starDate.Direction - _Date.BigStarRadius) / (float)starDate.TimeFalling;

        // 1フレームにX軸(もしくはZ軸)に進む角速度
        starDate.AngularVelocity_DegreeXZ = Random.Range(_Date.DegreeXZ_Miu, _Date.DegreeXZ_Max);
        // 1フレームにY軸に進む角速度
        starDate.AngularVelocity_DegreeY = Random.Range(_Date.DegreeXZ_Miu, _Date.DegreeXZ_Max);
        // 現在X軸(もしくはZ軸)による角度
        starDate.DegreeXZ = Random.Range(0, 360);
        // 現在Y軸による角度
        starDate.DegreeY = Random.Range(0, 360);

        // 名前を変える
        starDate.name = (starkind == Kind.ALWAYSMOVE) ?  "TheStarAlwaysMove" : 
                        (starkind == Kind.MOVEANDFALL) ? "TheStarMoveAndFall":
                                                         "TheStarJustFall";

        // 星を配置する
        SetPosition(newstar);

    // --------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 星を配置する
    /// </summary>
    /// <param name="star">星</param>
    private void SetPosition(GameObject star)
    {
        // 星のデータ
        StarDate starDate = star.GetComponent<StarDate>();

        // XZ軸方向に進む角度をデグリーからラジアンに変換
        float XZradian = starDate.DegreeXZ * Mathf.Deg2Rad;
        // Y軸方向に進む角度をデグリーからラジアンに変換
        float Yradian = starDate.DegreeY * Mathf.Deg2Rad;
        // 現在の星と惑星の距離
        float radius = starDate.Range;

        // 星の位置
        Vector3 starpos = new Vector3(radius * Mathf.Cos(Yradian) * Mathf.Sin(XZradian),
                                      radius * Mathf.Sin(Yradian),
                                      radius * Mathf.Cos(Yradian) * Mathf.Cos(XZradian));

        //  [現在の星の位置]    =       [惑星の位置]        + [星の位置]  
        star.transform.position = planet.transform.position + starpos;
    }

    /// <summary>
    /// 円に沿って星が動く
    /// </summary>
    private void ParallelToCircle(GameObject star)
    {
        // 星のデータ
        StarDate starDate = star.GetComponent<StarDate>();
        // XZ軸方向に進む
        starDate.DegreeXZ += starDate.AngularVelocity_DegreeXZ;
        // Y軸方向に進む
        starDate.DegreeY += starDate.AngularVelocity_DegreeY;

        // 星を配置する
        SetPosition(star);      
    }

    /// <summary>
    /// 穴に落ちて消える
    /// </summary>
    /// <param name="star">星</param>
    private void FallHoleAndDestory(GameObject star)
    {
        // 惑星と星の距離
        Vector3 range =  planet.transform.position - star.transform.position;
        // 正規化する
        range.Normalize();

        // レイの中点
        Vector3 original = star.transform.position;
        // レイの向き
        Vector3 direction = range;
        // レイの長さ
        float length = (_Date.SmallStarRadius * 2) * 2;

        // レイを作成する
        Ray ray = new Ray(original, direction);
        // レイを可視化する
        //Debug.DrawRay(ray.origin, ray.direction, Color.white, 10.0f);

        // レイが当たったオブジェクトの情報
        RaycastHit hit;

        // レイとオブジェクトの当たり判定
        if(!Physics.Raycast(ray,out hit, length))
        {
            // 惑星の穴の奥まで落ちる設定をする
            star.GetComponent<StarDate>().IsFallHole = true;
        }
    }

 }