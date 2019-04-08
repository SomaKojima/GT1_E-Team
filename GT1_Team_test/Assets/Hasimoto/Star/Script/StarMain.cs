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

    // 仮の時間
    private float time = 180.0f;
    int i = 0;
    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag("Planet");

        // 現在星が動く半径
       // nowradius = _Date.DIRECTION;

    }

    void Update()
    {
        // <落ちる時に必用になる処理> ----------------------------------------------------------------------------       
        //--------------------------------------------------------------------------------------------------------

        // 3秒ごとに星を新しく作成する

        if (time == 180.0f)
        {
            Create();
            time = 0.0f;
        }
        
        // 円に沿って星が動く
        ParallelToCircle();

        // 星を消す
        Destroy();

        // 時間を計る
        time++;


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
        starDate.TimeMove = 0.0f;
        // 星が宇宙から惑星に落ちる時間
        starDate.TimeFalling = 180.0f;
        // 星が惑星上に滞在する時間
        starDate.TimeState = 10800.0f;

        // 星と惑星の距離 と 現在の星と惑星の距離
        starDate.Direction = starDate.Radius = 10.0f;
        // 1フレームに縮む半径の長さを求める
        starDate.RadiusShrinkage = (starDate.Direction - _Date.radius) / (float)starDate.TimeFalling;

        // 1フレームにX軸(もしくはZ軸)に進む角速度
        starDate.AngularVelocity_DegreeXZ = Random.Range(1.0f, 5.0f);//1.0f
        // 1フレームにY軸に進む角速度
        starDate.AngularVelocity_DegreeY = Random.Range(1.0f, 5.0f);//3.0f
        // 現在X軸(もしくはZ軸)による角度
        starDate.DegreeXZ = Random.Range(0, 360);
        // 現在Y軸による角度
        starDate.DegreeY = Random.Range(0, 360);

    // --------------------------------------------------------------------------------------------
    }

    /// <summary>
    /// 円に沿って星が動く
    /// </summary>
    private void ParallelToCircle()
    {

        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            // 星のデータ
            StarDate starDate = star.GetComponent<StarDate>();

            // 星が宇宙上に動き始めてから惑星上に落ちるまでの時間
            float timeMoveFalling = starDate.TimeMove + starDate.TimeFalling;

            if (starDate.Time < timeMoveFalling)
            {

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
                star.transform.position =  planet.transform.position + starpos;

                // XZ軸方向に進む
                starDate.DegreeXZ += starDate.AngularVelocity_DegreeXZ;
                // Y軸方向に進む
                starDate.DegreeY += starDate.AngularVelocity_DegreeY;

                // <落ちる時に必用になる処理> ----------------------------------------------------------------------------
                
                // 半径を縮む
                starDate.Radius -= starDate.RadiusShrinkage;
                // 時間を進める
                //starDate.Time++;
                
                // ----------------------------------------------------------------------------------------
            }
        }
    }

    /// <summary>
    /// 星を消す
    /// </summary>
    private void Destroy()
    {
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {   
            // 星のデータ
            StarDate starDate = star.GetComponent<StarDate>();

            // 星が宇宙上に動き始めてから惑星上に生存するまでの時間
            float timeMoveState = starDate.TimeMove + starDate.TimeFalling + starDate.TimeState;

            if (starDate.Time > timeMoveState)
            {
                // 星を消す
                Destroy(star);
                
            }
            starDate.Time++;
        }

    }

 }