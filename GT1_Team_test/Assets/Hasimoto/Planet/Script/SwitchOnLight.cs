using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// 惑星に明かりに灯す
/// </summary>
public class SwitchOnLight : MonoBehaviour
{
   // データ
    public GameSceneDate _Date;

    // 惑星全体にほんのわずかに灯す光
    public GameObject Final_DirectionLight;


    // 惑星
    private GameObject planet;
    // 進んだ距離
    private float speed = 0.0f;
    // 直径
    private float diameter = 0.0f;

    // 惑星に明かりに灯すか
    private bool IsswitchOn = false;
    // A君がいる位置
    private Vector3 akunPos;


    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag(_Date.PlanetTag);

        // 明かりを灯す中点を反映させる
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosX", _Date.LightPos.x);
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosY", _Date.LightPos.y);
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosZ", _Date.LightPos.z);

        // 直径を設定する
        diameter = _Date.BigStarRadius * 2;

        //  惑星全体にほんのわずかに灯す光を非表示する
        Final_DirectionLight.SetActive(false);
    }

    void Update()
    {
        // 惑星に明かりに灯す 
        if(IsswitchOn) SwitchOnPlanet();

    }

    /// <summary>
    /// 惑星に明かりに灯す準備を行う
    /// </summary>
    /// <param name="AkunPos">A君がいる位置</param>
    public void Initialize_SwitchOn(Vector3 AkunPos)
    {
        // 惑星に明かりに灯す
        IsswitchOn = true;

        // A君がいる位置を取得する
        akunPos = AkunPos;

        //  惑星全体にほんのわずかに灯す光を表示する
        Final_DirectionLight.SetActive(true);
    }

    /// <summary>
    /// 惑星に明かりに灯す
    /// </summary>
    private void SwitchOnPlanet()
    {
        // 常に明かりの領域を広げる
        speed += _Date.SpeedSwitchOn;

        // 反映させる
        planet.GetComponent<Renderer>().material.SetFloat("_Radiuas", speed);         // 速さ
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosX", akunPos.x);   //  灯す位置 X
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosY", akunPos.y);   //  灯す位置 Y
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosZ", akunPos.z);   //  灯す位置 Z
    }

}
