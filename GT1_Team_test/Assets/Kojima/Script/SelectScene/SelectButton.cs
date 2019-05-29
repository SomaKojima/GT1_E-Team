using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SelectButton : MonoBehaviour
{
    public string name;
    public string sceneName;

    GameObject panel;
    SelectFadeIn selectFadeIn;
    bool isPush = false;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Panel");
        selectFadeIn = panel.GetComponent<SelectFadeIn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectFadeIn.GetAlpha() >= 1.0f && isPush)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    // マウスカーソルが入った
    public void OnPointerEnter()
    {
        GameObject.Find("SelectPlanetManager").GetComponent<SelectPlanetManager>().ChangePlanet(name);
        GameObject.Find("cursor").GetComponent<SelectSceneCorsor>().target = this.GetComponent<RectTransform>();
    }

    // クリック
    public void OnClick()
    {
     
        // ハシモト ------------------------------------------------------------------
        // 効果音を鳴らす
        SoundManager.Instance.PlaySe("click01");
        //----------------------------------------------------------------------------
        isPush = true;
        selectFadeIn.isFadeOut = true;
    }
}
