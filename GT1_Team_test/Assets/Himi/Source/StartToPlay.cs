using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartToPlay : MonoBehaviour
{
    public SelectCursor button;

    public bool isChengeSceneFlag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button.m_collideTag == "START" &&
            Input.GetMouseButtonDown(0))
        {
            isChengeSceneFlag = true;

            // ハシモト ------------------------------------------------------------------
            // 効果音を鳴らす
            SoundManager.Instance.PlaySe("click");
            //----------------------------------------------------------------------------
        }
    }
}