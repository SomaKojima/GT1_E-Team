using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星を投げて地面に当たると、星が消える処理
/// </summary>
public class StarThrowandDelete : MonoBehaviour
{
    // データ
    [SerializeField] private GameSceneDate date;
    // 星が惑星に当たった時に描画するエフェクト
    [SerializeField] private GameObject effectPrefab_starhitplanet;
    // 星が惑星に当たった時に惑星上に光るスポットライト 
    [SerializeField] private GameObject Star_SpotLight;
    // 惑星とスポットライトの距離
    [SerializeField] private float radian = 3.0f;
    // 惑星
    private GameObject planet;

    void Start()
    {
        // 惑星を探す
        planet = GameObject.FindGameObjectWithTag(date.PlanetTag);
    }
   
    void Update()
    {
        // 投げられた星が地面に当たって消える
        ThrowAndDleate();
    }

    /// <summary>
    /// 投げられた星が地面に当たって消える
    /// </summary>
    public void ThrowAndDleate()
    {
        // 複数の星を探す
        GameObject[] stars = GameObject.FindGameObjectsWithTag(date.StarTag);

        // 一つ一つの星
        foreach (GameObject star in stars)
        {
            // 星のデータ
            StarDate stardate = star.GetComponent<StarDate>();

            // 指定された星が投げられ地面に接触した場合、星を消す
            if ((stardate.IsThrow) && (HitStarPlanet(star)))
            {
                // エフェクトを作成する
                GameObject newEffect = Instantiate(effectPrefab_starhitplanet,Vector3.zero, Quaternion.identity) as GameObject;

                // エフェクトに名前を付ける
                newEffect.name = "Effect_StarHitPlanet";

                // 位置や向きを決める
                newEffect.GetComponent<StarEffect_HitPlanet>().DecideDirection(star, planet);

                // ----------------------------------------------------------------------------------------------------------------

                // 惑星上に光るスポットライトを作成する
                GameObject newSpotLight = Instantiate(Star_SpotLight, Vector3.zero, Quaternion.identity) as GameObject;

                // そのライトに名前を付ける
                newSpotLight.name = "ThrowStar_SpotLight";

                // 位置や向きを決める
                DecideDirection(newSpotLight, star, planet);

                // ----------------------------------------------------------------------------------------------------------------
                // 星を消す
                Destroy(star);
            }
        }
    }

    /// <summary>
    ///  星のレイと惑星の衝突判定
    /// </summary>
    /// <param name="star">星</param>
    /// <returns>衝突判定</returns>
    private bool HitStarPlanet(GameObject star)
    {
        // 惑星と星の距離
        Vector3 range = planet.transform.position - star.transform.position;
        // 正規化する
        range.Normalize();

        // レイの中点
        Vector3 original = star.transform.position;
        // レイの向き
        Vector3 direction = range;
        // レイの長さ
        float length = (date.SmallStarRadius * 2) * 2;

        // レイを作成する
        Ray ray = new Ray(original, direction);
        // レイを可視化する
        //Debug.DrawRay(ray.origin, ray.direction, Color.white, 10.0f);

        // レイが当たったオブジェクトの情報
        RaycastHit hit;

        //  星のレイと惑星の衝突判定
        if (Physics.Raycast(ray, out hit, length))　
        {
            return true;
        }
        else
        {
            return false;
        }
      
    }

    public void DecideDirection(GameObject spotlight, GameObject star, GameObject planet)
    {
        // 惑星に対しての向きを取得する
        Vector3 dic = planet.transform.position - star.transform.position;

        // その向きを正規化する
        dic.Normalize();

        // 位置を決める
        spotlight.transform.position = star.transform.position - dic * radian;

        // 惑星に対しての向きに回転する
        spotlight.transform.localRotation = Quaternion.LookRotation(dic);

    }

}
