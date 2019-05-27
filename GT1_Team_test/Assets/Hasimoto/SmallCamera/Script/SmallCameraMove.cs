using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCameraMove : MonoBehaviour
{
    // ミニマップ
    public GameObject miniMap;

    // 向き
    private Quaternion angle = Quaternion.identity;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // 向きと回転を合わせる & ミニマップを表示、非表示する
    public void FitMainCamera(GameObject mainmcamera,bool minimapflag)
    {
        // 位置
        this.transform.position = mainmcamera.transform.position;

        // 向き
        transform.rotation = mainmcamera.transform.rotation;

        // ミニマップを表示、非表示する
        miniMap.SetActive(minimapflag);
    }

}
