using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveSphere1 : MonoBehaviour {
    // サイズ
    private float scale = 0.0f;
    // 動くスピード
    private  float SPEED = 0.05f;
    // サイズの範囲
    public float MIU = 0.0f;     // 最小値
    public float MAX = 10.0f;    // 球の大きさ

    bool flag = false;
    void Start ()
    {
      
    }
	
	void Update ()
    {
        // キー操作でサイズを変える
        //if (!((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.DownArrow))))
        //{
        //   if (Input.GetKey(KeyCode.UpArrow))   scale += -SPEED; 
        //   if (Input.GetKey(KeyCode.DownArrow)) scale += +SPEED;
        //}

        // キー操作が出来ないため、自動的に変換する
        scale += +SPEED;


        // 範囲の宣言
        //if (scale < MIU) { scale = MIU; SPEED *= -1; }
        //if (scale > MAX) { scale = MAX; SPEED *= -1; }

        if(Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("ResultScene 1");
        }

        //  サイズを変える
        //this.transform.localScale = new Vector3(scale,scale,scale);
    }
    
   
   
}
