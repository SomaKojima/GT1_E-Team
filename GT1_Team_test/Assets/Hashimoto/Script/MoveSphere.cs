using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {

    // サイズ
    private float scale = 0.0f;
    // 動くスピード
    private const float SPEED = 0.05f;
    // サイズの範囲
    private const float MIU = 0.0f;     // 最小値
    private const float MAX = 10.0f;    // 球の大きさ

    void Start ()
    {
		
	}
	
	void Update ()
    {
        // キー操作でサイズを変える
        if (!((Input.GetKey(KeyCode.UpArrow)) && (Input.GetKey(KeyCode.DownArrow))))
        {   if (Input.GetKey(KeyCode.UpArrow))   scale += -SPEED;
            if (Input.GetKey(KeyCode.DownArrow)) scale += +SPEED;
        }
        // 範囲の宣言
        if (scale < MIU) scale = MIU;
        if (scale > MAX) scale = MAX;

        Debug.Log(scale);

        //  サイズを変える
        this.transform.localScale = new Vector3(scale,scale,scale);
    }
}
