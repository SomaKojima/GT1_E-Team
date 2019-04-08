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


    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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

                    if (col.gameObject.GetComponent<collision>().GetDustCount() >= 3)
                    {
                        text.GetComponent<Text>().text = "ありがとう！！これで世界は救われた";
                        Debug.Log("game clear"); // ログを表示する
                    }
                    else
                    {
                        text.GetComponent<Text>().text = "星のかけらをあと" + (3 - col.gameObject.GetComponent<collision>().GetDustCount()) + "つ持ってきてね";
                        Debug.Log("talk.now"); // ログを表示する
                        col.gameObject.GetComponent<collision>().SetTalkFlag();
                        GameDirecter.gameObject.GetComponent<SwitchOnLight>().SwitchOnPlanet();
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
}
