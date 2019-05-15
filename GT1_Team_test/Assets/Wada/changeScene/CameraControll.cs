using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    private GameObject mainCam; // メインカメラ
    private GameObject subCam;  // サブカメラ

    // Start is called before the first frame update
    void Start()
    {
        // メインカメラとサブカメラを取得
        mainCam = GameObject.Find("MainCamera");
        subCam = GameObject.Find("SubCamera");

        // サブカメラを非アクティブにする
        subCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーが押されたらサブカメラをアクティブにする
        if(Input.GetKey("z"))
        {
            // サブカメラをアクティブに設定
            mainCam.SetActive(false);
            subCam.SetActive(true);
        }
        else
        {
            // メインカメラをアクティブに設定
            mainCam.SetActive(true);
            subCam.SetActive(false);
        }
    }

    internal void ChangeTalkMode(Transform childTransform, GameObject cameraPos)
    {
        throw new NotImplementedException();
    }
}
