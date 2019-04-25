using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject nMission;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject wishSelect;


    private int count = 0;
    private int selectCount = 0;
    private bool flagA = true;
    private bool menuFlag = true;
    private int menuState = 0;
    private bool selectFlag = true;
    private int selectState = 0;
    private int StartScreenWidth = 980;
    private int StartScreenHeight = 551;

    // Start is called before the first frame update
    void Start()
    {
        //float screenMoveW = (float)Screen.width / (float)StartScreenWidth;
        //wishSelect.transform.Translate(300.0f * screenMoveW, 0, 0);

        menuState = 0;
        selectState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Screen.width + ":" + Screen.height); // ログを表示する
        float screenMoveW = (float)Screen.width / (float)StartScreenWidth;
        //Debug.Log(screenMoveW);

        //rimitTime = rimitTime - Time.deltaTime;
        DustCounter.GetComponent<Text>().text = "ｘ"+(player.GetComponent<collision>().GetDustCount())+"こ";
        //Timer.GetComponent<Text>().text = "" + ((int)rimitTime / 60).ToString("00") + ":" + ((int)rimitTime % 60).ToString("00");
        if(Input.GetKeyDown(KeyCode.G))
        {
            Timer.GetComponent<Text>().text = "終了です";
            //SceneManager.LoadScene("GameOver");
            panel.GetComponent<FadeController>().SetFlag(2);
        }

        if ((player.GetComponent<collision>().GetFlagA()) && (flagA))
        {
            if (count == 0)
            {
                if(!menuFlag)
                {
                    mission.transform.Translate(300.0f*screenMoveW, 0, 0);
                    nMission.transform.Translate(-300.0f * screenMoveW, 0, 0);
                }
                menuState = 2;
                menuFlag = true;
                flagA = false;
            }
        }

        if (menuState != 0)
        {
            count++;
            if (count < 16)
            {
                if (menuFlag)
                {
                    mission.transform.Translate(20.0f * screenMoveW, 0, 0);
                    nMission.transform.Translate(-20.0f * screenMoveW, 0, 0);
                }
                else
                {
                    mission.transform.Translate(-20.0f * screenMoveW, 0, 0);
                    nMission.transform.Translate(20.0f * screenMoveW, 0, 0);
                }
            }
            else
            {
                count = 0;
                menuState = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
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


        if (selectState != 0)
        {
            selectCount++;
            if (selectCount < 16)
            {
                if (selectFlag)
                {
                    wishSelect.transform.Translate(-20.0f * screenMoveW, 0, 0);
                }
                else
                {
                    wishSelect.transform.Translate(20.0f * screenMoveW, 0, 0);
                }
            }
            else
            {
                selectCount = 0;
                selectState = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (selectState == 0)
            {
                if (selectFlag)
                {
                    selectFlag = false;
                }
                else
                {
                    selectFlag = true;
                }
                selectState = 1;
            }
        }
    }

    public float GetTime()
    {
        return rimitTime;
    }

    public int GetDust()
    {
        return player.GetComponent<collision>().GetDustCount();
    }


}
