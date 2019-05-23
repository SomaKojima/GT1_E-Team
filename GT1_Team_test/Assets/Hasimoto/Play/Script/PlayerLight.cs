// プレイヤーにアタッチするスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // データ
    public GameSceneDate _Date;
    // 人の周りに光を灯す半径
    [SerializeField]
    private float radius = 5.0f;

    // 惑星
    private GameObject planet;
    // 惑星のマテリアル
    private Material planetMaterial;
    // プレイヤーのTransform
    private Transform playerTransform;

    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag(_Date.PlanetTag);
        // 惑星のマテリアル
        planetMaterial = planet.GetComponent<Renderer>().material;
        // プレイヤーのTransform
        playerTransform = this.transform;

        // 惑星上で人の周りに灯す半径
        planetMaterial.SetFloat("_Radiuas", radius);

    }

    void Update()
    {
#if true
        // リストを作成
        List<Vector4> list = new List<Vector4>();
        // リストに追加
        list.Add(new Vector4(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z, 0.0f));
        

        // リストをスプライトへ渡す
        planetMaterial.SetVectorArray("_LightPos", list);
        // リストのサイズスプライトへ渡す
        planetMaterial.SetInt("_ArrayLength", list.Count);
        // リストをリセットする
        list.Clear();
#endif
    }


    /// <summary>
    ///  取得・設定関数
    /// </summary>

    // 惑星上で人の周りに灯す半径を反映させる
    public float Radius { get { return radius; } set { radius = value;  planetMaterial.SetFloat("_Radiuas", radius); } }

}