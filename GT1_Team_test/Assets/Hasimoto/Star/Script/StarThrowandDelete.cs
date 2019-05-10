using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 星を投げて地面に当たると、星が消える処理
/// </summary>
public class StarThrowandDelete : MonoBehaviour
{
    // データ
    [SerializeField] private Date date;
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
            if ((stardate.IsThrow)&&(HitStarPlanet(star))) Destroy(star);
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

}
