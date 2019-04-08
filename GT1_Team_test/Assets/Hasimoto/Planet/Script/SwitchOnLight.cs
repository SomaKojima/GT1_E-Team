﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchOnLight : MonoBehaviour
{
    // 惑星
    private GameObject planet;
    // データ
    public Date _Date;
        
    // 進んだ距離
    private float speed = 0.0f;
    // 直径
    private float diameter = 0.0f;

    void Start()
    {
        // 惑星を呼ぶ
        planet = GameObject.FindGameObjectWithTag("Planet");

        // 明かりを灯す中点を反映させる
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosX", _Date.LightPos.x);
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosY", _Date.LightPos.y);
        planet.GetComponent<Renderer>().material.SetFloat("_LightPosZ", _Date.LightPos.z);

        // 直径を設定する
        diameter = _Date.RADIUS * 2;
    }

    void Update()
    {
        // 常に明かりの領域を広げる
        speed += _Date.SpeedSwitchOn;
        // 反映させる
        planet.GetComponent<Renderer>().material.SetFloat("_Radiuas", speed);

        //  リザルトシーンに変える
        //if (speed > diameter)
        //{
        //    SceneManager.LoadScene("ResultScene");
        //}
    }
}
