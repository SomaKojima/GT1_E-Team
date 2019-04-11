﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField]
    private GameObject text;
    [SerializeField]
    private GameObject mw;
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject GameDirecter;
    [SerializeField]
    private GameObject panel;

    public int clearStarCount = 10;


    private bool flag = true;
    private bool clear = false;
    private Color ambient = new Color(0, 0, 0, 1);

    public static float clearTime;
    public static int clearDust;
    public static int clearWish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(clear)
        {
            ambient.r++;
            ambient.b++;
            ambient.g++;
            RenderSettings.ambientLight = new Color(ambient.r / 120, ambient.g / 120, ambient.b / 120, 1);
            if(ambient.r==140)
            {
                clearWish = 1;
                clearTime = UI.GetComponent<PlayerUI>().GetTime();
                clearDust = UI.GetComponent<PlayerUI>().GetDust();
                panel.GetComponent<FadeController>().SetFlag(3);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            icon.SetActive(true);
            Debug.Log("talk.ok"); // ログを表示する
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            flag = true;
            icon.SetActive(false);
            text.SetActive(false);
            mw.SetActive(false);
            UI.SetActive(true);
            Debug.Log("talk.ng"); // ログを表示する
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (flag)
                {
                    flag = false;
                    mw.SetActive(true);
                    text.SetActive(true);
                    UI.SetActive(false);

                    if (col.gameObject.GetComponent<collision>().GetDustCount() >= clearStarCount)
                    {
                        text.GetComponent<Text>().text = "ありがとう！！これで世界は救われた";
                        Debug.Log("game clear"); // ログを表示する
                        //GameDirecter.gameObject.GetComponent<SwitchOnLight>().SwitchOnPlanet();
                        GameDirecter.SetActive(true);
                        col.gameObject.GetComponent<collision>().Clear();
                        clear = true;
                    }
                    else
                    {
                        text.GetComponent<Text>().text = "星のかけらをあと" + (clearStarCount - col.gameObject.GetComponent<collision>().GetDustCount()) + "つ持ってきてね";
                        Debug.Log("talk.now"); // ログを表示する
                        col.gameObject.GetComponent<collision>().SetTalkFlag();
                        //GameDirecter.gameObject.GetComponent<SwitchOnLight>().SwitchOnPlanet();
                    }
                }
                else
                {
                    UI.SetActive(true);
                    flag = true;
                    text.SetActive(false);
                    mw.SetActive(false);
                    Debug.Log("talk.cancel"); // ログを表示する
                }
            }
        }
    }

    public static float GetTime()
    {
        return clearTime;
    }

    public static int GetDust()
    {
        return clearDust;
    }

    public static int GetWish()
    {
        return clearWish;
    }
}