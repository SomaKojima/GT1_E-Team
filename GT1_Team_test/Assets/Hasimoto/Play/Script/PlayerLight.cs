// プレイヤーにアタッチするスクリプト

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    // データ
    public Date _Date;
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

        // 惑星で光を灯す半径
        planetMaterial.SetFloat("_Radiuas", radius);

        // 惑星で光を灯す位置
        //planetMaterial.SetFloat("_LightPosX", playerTransform.position.x);
        //planetMaterial.SetFloat("_LightPosY", playerTransform.position.y);
        //planetMaterial.SetFloat("_LightPosZ", playerTransform.position.z);

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
        //// ------------------------------------------------------------------------------

        //// 惑星で光を灯す位置
        //planetMaterial.SetFloat("_LightPosX", playerTransform.position.x);
        //planetMaterial.SetFloat("_LightPosY", playerTransform.position.y);
        //planetMaterial.SetFloat("_LightPosZ", playerTransform.position.z);
    }
}