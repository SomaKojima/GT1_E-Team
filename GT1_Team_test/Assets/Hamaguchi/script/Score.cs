using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private GameObject ClearTime;
    [SerializeField]
    private GameObject ClearWish;
    [SerializeField]
    private GameObject ClearDust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int time = 180-(int)talk.GetTime();
        int dust = talk.GetDust();
        int wish = talk.GetWish();
        ClearTime.GetComponent<Text>().text = "クリアタイム　　　：　" + time.ToString() + "秒";
        ClearDust.GetComponent<Text>().text = "入手した☆　　　　：　" + dust.ToString() + "個";
        ClearWish.GetComponent<Text>().text = "願いを叶えた人数　：　" + wish.ToString() + "人";

        Debug.Log(dust); // ログを表示する
    }
}
