using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRadiation : MonoBehaviour
{

    private ParticleSystem particle;       // パーティクルシステム

    private SelectCursor   selectCursorCs; // SelectCursorスクリプト

    // Start is called before the first frame update
    void Start()
    {
        // パーティクルシステムの初期化
        particle = this.GetComponent<ParticleSystem>();
        // パーティクルの停止
        particle.Stop();

        // SelectCursorスクリプトを取得
        selectCursorCs = gameObject.GetComponent<SelectCursor>();
    }

    // Update is called once per frame
    void Update()
    {

        // 複数の流れ星を取得
        GameObject[] shootingStars = GameObject.FindGameObjectsWithTag("shootingstarPrefab");

        // 複数の流れ星
        foreach (GameObject obj in shootingStars)
        {
            // オブジェクトが無かったら処理をしない
            if (obj == null) return;

            // パーティクルの出す位置を設定 
            this.transform.position = obj.transform.position;

            // カーソルが触れたもののタグがshootingstarだったら
            if (selectCursorCs.m_collideTag == "shootingstarPrefab")
            {
                //パーティクルの再生
                particle.Play();
            }
 
        }
    }
}
