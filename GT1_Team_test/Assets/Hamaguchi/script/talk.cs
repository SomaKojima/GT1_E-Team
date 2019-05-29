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
    [SerializeField]
    private GameObject mw;
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject GameDirecter;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject comp;

    public int clearStarCount = 10;


    private bool flag = true;
    private bool clear = false;
    private Color ambient = new Color(0, 0, 0, 1);

    public static float clearTime;
    public static int clearDust;
    public static int clearWish;
    private  bool talkFlag = false;
    private bool firstFlag = false;
    private bool compFlag = false;
    [SerializeField]
    private int stage = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(clear)
        {
            UI.SetActive(false);
            ambient.r++;
            ambient.b++;
            ambient.g++;
            RenderSettings.ambientLight = new Color(ambient.r / 120, ambient.g / 120, ambient.b / 120, 1);
            if(ambient.r==140)
            {
                clearWish = 1;
                clearTime = UI.GetComponent<PlayerUI>().GetTime();
                clearDust = UI.GetComponent<PlayerUI>().GetDust();
                //panel.GetComponent<FadeController>().SetFlag(3);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            icon.SetActive(true);
            icon.GetComponent<UIController>().SetTarget(this.gameObject.transform);
            Debug.Log("talk.ok"); // ログを表示する
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "player")
        {
            talkFlag = false;
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
                SoundManager.Instance.PlaySe("TalkSE");

                talkFlag = true;
                if (flag)
                {
                    flag = false;
                    mw.SetActive(true);
                    text.SetActive(true);
                    UI.SetActive(false);

                    if ((col.gameObject.GetComponent<collision>().GetDustCount() >= clearStarCount)&&(firstFlag)&&(!clear))
                    {
                        if (this.gameObject.name == "areaA")
                        {

                            text.GetComponent<Text>().text = "ありがとう！！これで世界は救われた";

                            // ハシモト------------------------------------------------------------------
                            // 惑星全体を灯す準備を行う
                            GameObject.Find("Director").GetComponent<SwitchOnLight>().Initialize_SwitchOn(this.gameObject.transform.position);


                            //---------------------------------------------------------------------------
                            UI.SetActive(false);

                            SoundManager.Instance.PlaySe("MissionClear");
                            Debug.Log("game clear"); // ログを表示する
                                                     //GameDirecter.gameObject.GetComponent<SwitchOnLight>().SwitchOnPlanet();
                            GameDirecter.SetActive(true);
                            col.gameObject.GetComponent<collision>().Clear();
                            clear = true;
                        }
                        else if (this.gameObject.name == "areaB")
                        {
                            // ハシモト------------------------------------------------------------------
                            // 願いことが叶って、オブジェクトを表示もしくは非表示する
                            transform.root.gameObject.GetComponent<CreateOrDeleteObject>().Clear();
                            //---------------------------------------------------------------------------

                            if(stage==1)
                            {
                                text.GetComponent<Text>().text = "大きな木がにょきにょきと！";
                            }
                            else
                            {
                                text.GetComponent<Text>().text = "ありがとう！これで水浴びができるよ！";
                            }
                            
                            if (!compFlag)
                            {
                                col.gameObject.GetComponent<collision>().SetDustCount(clearStarCount);
                                comp.SetActive(true);
                                compFlag = true;
                                SoundManager.Instance.PlaySe("MissionClear");
                                
                                Debug.Log("doaho"); // ログを表示する

                            }
                        }
                        else if (this.gameObject.name == "areaC")
                        {
                            // ハシモト------------------------------------------------------------------
                            // 願いことが叶って、オブジェクトを表示もしくは非表示する
                            transform.root.gameObject.GetComponent<CreateOrDeleteObject>().Clear();
                            //---------------------------------------------------------------------------

                            

                            if (stage == 1)
                            {
                                text.GetComponent<Text>().text = "やったぁ、岩が壊れたぞ！";
                            }
                            else
                            {
                                text.GetComponent<Text>().text = "ありがとう！これでAくんに合えるぞ！";
                            }
                            if (!compFlag)
                            {
                                col.gameObject.GetComponent<collision>().SetDustCount(clearStarCount);
                                comp.SetActive(true);
                                SoundManager.Instance.PlaySe("MissionClear");

                                compFlag = true;
                            }
                        }
                    }
                    else
                    {
                        if (this.gameObject.name == "areaA")
                        {
                            if (!compFlag)
                            {
                                text.GetComponent<Text>().text = "星のかけらをあと" + (clearStarCount - col.gameObject.GetComponent<collision>().GetDustCount()) + "つ持ってきてね";
                            }
                           
                            Debug.Log("talk.now"); // ログを表示する
                            col.gameObject.GetComponent<collision>().SetFlagA();
                            

                            //GameDirecter.gameObject.GetComponent<SwitchOnLight>().SwitchOnPlanet();
                        }
                        else if (this.gameObject.name == "areaB")
                        {
                            if (!compFlag)
                            {
                                text.GetComponent<Text>().text = "星のかけらをあと" + (clearStarCount - col.gameObject.GetComponent<collision>().GetDustCount()) + "つ持ってきてね";
                            }
                            else
                            {
                                if (stage == 1)
                                {
                                    text.GetComponent<Text>().text = "大きな木がにょきにょきと！";
                                }
                                else
                                {
                                    text.GetComponent<Text>().text = "ありがとう！これで水浴びができるよ！";
                                }
                            }
                            col.gameObject.GetComponent<collision>().SetFlagB();
                        }
                        else if (this.gameObject.name == "areaC")
                        {
                            if (!compFlag)
                            {
                                text.GetComponent<Text>().text = "星のかけらをあと" + (clearStarCount - col.gameObject.GetComponent<collision>().GetDustCount()) + "つ持ってきてね";
                            }
                            else
                            {
                                if (stage == 1)
                                {
                                    text.GetComponent<Text>().text = "やったぁ、岩が壊れたぞ！";
                                }
                                else
                                {
                                    text.GetComponent<Text>().text = "ありがとう！これでAくんに合えるぞ！";
                                }
                            }
                            col.gameObject.GetComponent<collision>().SetFlagC();
                        }
                    }

                    if(!firstFlag)
                    {
                        if (this.gameObject.name == "areaA")
                        {
                            text.GetComponent<Text>().text = "この星を救うためには、☆の力が必要なんだ";
                            firstFlag = true;
                            SoundManager.Instance.PlaySe("MissionArart");

                        }
                        else if (this.gameObject.name == "areaB")
                        {
                            if (stage == 1)
                            {
                                text.GetComponent<Text>().text = "この辺に木を生やしたんだけど…";

                            }
                            else
                            {
                                text.GetComponent<Text>().text = "暑い…水浴びができる池を出現させてくれないか？";

                            }
                            firstFlag = true;
                            SoundManager.Instance.PlaySe("MissionArart");

                        }
                        else if (this.gameObject.name == "areaC")
                        {
                            if (stage == 1)
                            {
                                text.GetComponent<Text>().text = "この岩を壊すのを手伝ってくれないか？";

                            }
                            else
                            {
                                text.GetComponent<Text>().text = "Aくんが砂嵐に囲まれているんだ…！助けてくれ！";

                            }
                            firstFlag = true;
                            SoundManager.Instance.PlaySe("MissionArart");

                        }
                    }
                }
                else
                {
                    talkFlag = false;
                    UI.SetActive(true);
                    flag = true;
                    text.SetActive(false);
                    mw.SetActive(false);
                    Debug.Log("talk.cancel"); // ログを表示する
                    if (this.gameObject.name == "areaB")
                    {
                        col.gameObject.GetComponent<collision>().SetFlagB();
                    }
                    else if (this.gameObject.name == "areaC")
                    {
                        col.gameObject.GetComponent<collision>().SetFlagC();
                    }
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

    public bool GetFlag()
    {
        return talkFlag;
    }

    public GameObject GetTalk()
    {
        return transform.parent.gameObject;
    }
}
