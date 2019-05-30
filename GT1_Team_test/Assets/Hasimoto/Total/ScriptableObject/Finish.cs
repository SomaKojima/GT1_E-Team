using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Escキーでゲームを終了する
/// </summary>
public class Finish : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //  Escキーを押したら
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // ゲーム終了
            Quit();
        }
    }

    /// <summary>
    /// 終了処理
    /// </summary>
    private void Quit()
    {
    // エディター上で終了
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    // スタンドアロン上で終了    
    #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
    #endif
    }
}
