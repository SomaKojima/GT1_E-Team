using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerate : MonoBehaviour
{
    private GameObject shootingstar;            // 流れ星

    private float      delta = 0.0f;            // カウントする時間(秒)
    private float      shootingSpan = 0.0f;     // 降る間隔
    public  float      shootingSpanMin = 3.0f;  // 降る時間(最小)
    public  float      shootingSpanMax = 10.0f; // 降る時間(最大)

    // Start is called before the first frame update
    void Start()
    {
        // shootingPrefabを読み込み
        shootingstar = (GameObject)Resources.Load("shootingstarPrefab");
        // 降る間隔を設定
        shootingSpan = Random.Range(shootingSpanMin, shootingSpanMin);
    }

    // Update is called once per frame
    void Update()
    {
        // 時間経過
        this.delta += Time.deltaTime;
        // 降る間隔より時間経過が大きかったら
        if (this.delta > this.shootingSpan)
        {
            // カウントをリセット、降る感覚を再設定
            this.delta = 0;
            shootingSpan = Random.Range(shootingSpanMin, shootingSpanMax);

            // 流れ星を生成
            Instantiate(shootingstar, new Vector3(Random.Range(-1.0f, 10.0f), 4.0f, 0.0f), Quaternion.identity);
        }
    }
}
