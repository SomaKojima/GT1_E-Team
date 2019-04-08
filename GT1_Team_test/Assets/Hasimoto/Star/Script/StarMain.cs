using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float frame = 180.0f;

    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag(_Date.PlanetTag);

        // 新しい星を作成する時間
        timecreate = Random.Range(_Date.TimeCreate_Miu, _Date.TimeCreate_Max);
    }

    void Update()
    {
        // 時間ごとに星を新しく作成する
        if (frame == timecreate)
        {
            // 星を新しく作成する
            Create();
            
            // 改めて新しい星を作成する時間を決める
            timecreate = Random.Range(_Date.TimeCreate_Miu, _Date.TimeCreate_Max);
            
            // 時間をリセットする
            frame = 0.0f;
        }

        // 複数の星を呼ぶ
        foreach (GameObject star in GameObject.FindGameObjectsWithTag(_Date.StarTag))
        {
            foreach (Transform child in transform)
            {
                // スポットライトを探す
                Light light = child.GetComponent<Light>();

                if (light != null)
                {
                    Vector3 direction = star.transform.position - planet.transform.position;
                    direction.Normalize();

                    // Xの角度
                    float radianX = Mathf.Atan2(direction.z, direction.x);
                    // 三角形XZの斜辺の長さ
                    float radiusXZ = direction.x / Mathf.Cos(radianX);
                    // Yの角度
                    float radianY = Mathf.Atan2(direction.y, radiusXZ);
                    // Zの角度
                    float radianZ = 90.0f * Mathf.Deg2Rad - radianX;

                    // ラジアンからデグリーへ変換
                    Vector3 degree = new Vector3(radianX, radianY, radianZ) * Mathf.Rad2Deg;

                    // スポットライトの向きを調整する
                    light.transform.rotation = Quaternion.Euler(degree);
                }
            }

            // 星のデータ
            StarDate starDate = star.GetComponent<StarDate>();

            if (star == null) Debug.Log("NULL");
            if (starDate == null) Debug.Log("NULL");

            // 星の生存時間
            float startime = starDate.Time;
            
            // 星が宇宙上に動く時間
            float timeMove = starDate.TimeMove;
            // 星が宇宙上に動き始めてから惑星上に落ちるまでの時間
            float timeMoveFalling = timeMove + starDate.TimeFalling;
            // 星が宇宙上に動き始めてから惑星上に生存するまでの時間
            float timeMoveState = timeMoveFalling + starDate.TimeState;

            // 星が宇宙上に動き始めてから惑星上に落ちるまで
            if (startime < timeMoveFalling)
            {
                // 円に沿って星が動く
                ParallelToCircle(star);

                // 星が落ち始める準備
                if (startime >= timeMove)
                {
                    // 星が軌道する半径を縮む
                    starDate.Radius -= starDate.RadiusShrinkage;
                }
            }

            // 星を消す
            if(startime > timeMoveState)
            {
                Destroy(star);
            }
            else
            {
                // 星の生存時間を計る
                starDate.Time++;
            }
        }

        // フレームを計る
        frame++;
    }

    /// <summary>
    /// 星を作成する
    /// </summary>
    private void Create()
    {
        // 星を新しく作成する
        GameObject obj = Instantiate(starPrefab) as GameObject;

        // --------------------------------------------------------------------------------------------
        // 星のデータ
        StarDate starDate = obj.GetComponent<StarDate>();

        // 星が宇宙上に動く時間
        starDate.TimeMove = Random.Range(_Date.TimeMove_Miu, _Date.TimeMove_Max);
        // 星が宇宙から惑星に落ちる時間
        starDate.TimeFalling = Random.Range(_Date.TimeFall_Miu,_Date.TimeFall_Max);
        // 星が惑星上に滞在する時間
        starDate.TimeState = Random.Range(_Date.TimeState_Miu, _Date.TimeState_Miu);

        // 星と惑星の距離 と 現在の星と惑星の距離
        starDate.Direction = starDate.Radius = Random.Range(_Date.Direction_Miu, _Date.Direction_Max);
        // 1フレームに縮む半径の長さを求める
        starDate.RadiusShrinkage = (starDate.Direction - _Date.Radius) / (float)starDate.TimeFalling;

        // 1フレームにX軸(もしくはZ軸)に進む角速度
        starDate.AngularVelocity_DegreeXZ = Random.Range(_Date.DegreeXZ_Miu, _Date.DegreeXZ_Max);//1.0f
        // 1フレームにY軸に進む角速度
        starDate.AngularVelocity_DegreeY = Random.Range(_Date.DegreeXZ_Miu, _Date.DegreeXZ_Max);//3.0f
        // 現在X軸(もしくはZ軸)による角度
        starDate.DegreeXZ = Random.Range(0, 360);
        // 現在Y軸による角度
        starDate.DegreeY = Random.Range(0, 360);

    // --------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 円に沿って星が動く
    /// </summary>
    private void ParallelToCircle(GameObject star)
    {

        // 星のデータ
        StarDate starDate = star.GetComponent<StarDate>();

        // XZ軸方向に進む角度をデグリーからラジアンに変換
        float XZradian = starDate.DegreeXZ * Mathf.Deg2Rad;
        // Y軸方向に進む角度をデグリーからラジアンに変換
        float Yradian = starDate.DegreeY * Mathf.Deg2Rad;
        // 現在の星と惑星の距離
        float radius = starDate.Radius;

        // 星の位置
        Vector3 starpos = new Vector3(radius * Mathf.Cos(Yradian) * Mathf.Sin(XZradian),
                                      radius * Mathf.Sin(Yradian),
                                      radius * Mathf.Cos(Yradian) * Mathf.Cos(XZradian));

        //  [現在の星の位置]    =       [惑星の位置]        + [星の位置]  
        star.transform.position = planet.transform.position + starpos;

        // XZ軸方向に進む
        starDate.DegreeXZ += starDate.AngularVelocity_DegreeXZ;
        // Y軸方向に進む
        starDate.DegreeY += starDate.AngularVelocity_DegreeY;        
    }

 }