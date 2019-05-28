using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChengeSceneFade : MonoBehaviour
{
    private Image m_imageRenderer;       // スプライトレンダラー
    public string sceneName;

    private  StartToPlay startToPlayCS;

    // Start is called before the first frame update
    void Start()
    {
        m_imageRenderer = this.gameObject.GetComponent<Image>();
        startToPlayCS = GameObject.Find("start_ui").GetComponent<StartToPlay>();
    }

    // Update is called once per frame
    void Update()
    {
        var color = m_imageRenderer.color;

        // シーン遷移が起こったら
        if (startToPlayCS.isChengeSceneFlag == true)
        {
            // フェード
            color.a += 0.01f;
            m_imageRenderer.color = color;
        }

        if(color.a >= 2.0)
        {
            color.a = 2.0f;

            SceneManager.LoadScene(sceneName);
        }

        Debug.Log(color.a);
    }
}
