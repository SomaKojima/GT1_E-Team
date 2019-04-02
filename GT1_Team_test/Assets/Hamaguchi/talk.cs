using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    [SerializeField]
    private GameObject icon;
    [SerializeField]
    private GameObject text;
    
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
            icon.SetActive(false);
            text.SetActive(false);
            Debug.Log("talk.ng"); // ログを表示する
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "player")
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                text.SetActive(true);
                if (col.gameObject.GetComponent<collision>().dustCounter>=3)
                {
                    text.GetComponent<Text>().text = "ありがとう！！これで世界は救われた";
                    Debug.Log("game clear"); // ログを表示する
                }
                else
                {
                    text.GetComponent<Text>().text = "星のかけらを３つ持ってきてね";
                    Debug.Log("talk.now"); // ログを表示する
                }
            }
        }
    }
}
