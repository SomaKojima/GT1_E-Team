using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    float fadeSpeed = 0.02f;    // 透明度が変わるスピードを管理
    float red, green, blue, alfa;   // パネルの色、不透明度を管理

    public bool isFadeOut = false; // フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;  // フェードイン処理の開始、完了を管理するフラグ

    //ハマグチ追加
    private bool isChangeScene = false;
    private int sceneNum = 0;
    [SerializeField]
    private GameObject panel;

    Image fadeImage;    // 透明度を変更するパネルのイメージ

    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<Image>().enabled = true; // オフにしていたPanelのImageコンポーネントをオンに変更
        // GetComponent<Image>().color = new Color(255, 0, 0, 0.5f); // Imageのカラーを変更

        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChangeScene)
        {
            time++;

            if(panel==null)
            {
                Debug.Log("FadeControllerクラス中にあるpanel変数がNULLです！！");
            }

            panel.SetActive(false);
            if (isFadeIn)
            {
                StartFadeIn();
            }
            if (time > 2.0f)
            {
                isFadeOut = true;
                if (isFadeOut == true)
                {
                    StartFadeOut();
                    Invoke("ChangeScene", 3.5f);
                }
            }
        }
    }
    void StartFadeIn()
    {
        alfa -= fadeSpeed;                  // a)不透明度を徐々に下げる
        SetAlpha();                         // b)変更した不透明度パネルに反映する
        if (alfa <= 0)                       // c)完全に透明になったら処理を抜ける
        {
            isFadeIn = false;
            fadeImage.enabled = false;      // d)パネルの表示をオフにする
        }
    }

    void StartFadeOut()
    {
        Debug.Log("out");
        fadeImage.enabled = true;   // a)パネルの表示をオンにする
        alfa += fadeSpeed;          // b)不透明度を徐々に上げる
        SetAlpha();                 // c)変更した透明度をパネルに反映する
        if (alfa >= 1)               // d)完全に不透明になったら処理を抜ける
        {
            isFadeOut = false;
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }

    void ChangeScene()
    {
        //ハマグチ追加

        switch (sceneNum)
        {
            case 1:
                SceneManager.LoadScene("Play");
                break;
            case 2:
                SceneManager.LoadScene("GameOver");
                break;
            case 3:
                SceneManager.LoadScene("ResultScene 1");
                break;
            case 4:
                SceneManager.LoadScene("TitleScene 1");
                break;
        }
    }


    //ハマグチ追加
    public void SetFlag(int num)
    {
        sceneNum = num;
        isChangeScene = true;
    }
}
