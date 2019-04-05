using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject DustCounter;
    [SerializeField]
    private GameObject Timer;
    [SerializeField]
    private GameObject mission;
    [SerializeField]
    private float rimitTime = 0;
    [SerializeField]
    private GameObject player;

    private int count = 0;
    private bool flagA = true;
    private bool menuFlag = false;
    private int menuState = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rimitTime = rimitTime - Time.deltaTime;
        DustCounter.GetComponent<Text>().text = "ｘ"+(player.GetComponent<collision>().GetDustCount())+"こ";
        Timer.GetComponent<Text>().text = "" + ((int)rimitTime / 60).ToString("00") + ":" + ((int)rimitTime % 60).ToString("00");
        if(rimitTime<0)
        {
            Timer.GetComponent<Text>().text = "終了です";
        }

        if ((player.GetComponent<collision>().GetTalkFlag()) && (flagA))
        {
            menuState = 2;
            if (count < 15)
            {
                mission.transform.Translate(20.0f, 0, 0);
                menuFlag = true;
                flagA = false;
                count = 0;
                menuState = 1;
            }
        }

        if(menuState != 0)
        {
            count++;
            if(count<16)
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.X)&&(flagA))
        {
            if (menuState == 0)
            {
                if (menuFlag)
                {
                    menuFlag = false;
                }
                else
                {
                    menuFlag = true;
                }
                menuState = 1;
            }
        }
    }
}
