using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShooting : MonoBehaviour
{
    Vector3 starSpeed;

    // 流れ星のスピード
    public float starSpeedXMin = -0.05f;
    public float starSpeedXMax = -0.1f;
    public float starSpeedYMin = -0.03f;
    public float starSpeedYMax = -0.05f;

    // 星が破棄される座標
    public float starDestroyArea = -3.5f;

    // Use this for initialization
    void Start()
    {
        // 速度を初期化
        starSpeed = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        starSpeed.x = Random.Range(starSpeedXMin, starSpeedXMax);
        starSpeed.y = Random.Range(starSpeedYMin, starSpeedYMax);
        // 等速で落下する
        transform.Translate(starSpeed.x, starSpeed.y, 0);

        // 画面外に出たらオブジェクトを破棄する
        if (transform.position.y < starDestroyArea)
        {           
            Destroy(gameObject);
        }
    }
}
