using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCamera
{
    public GameObject camera;
    // ターゲットが吸い寄せられている惑星
    public GameObject planet;

    public GameObject m_target;
    public GameObject panel;
    float time = 0.0f;
    public float interval = 10.0f;
    int index = 0;

    // カメラとターゲットの最大距離
    public float max_distance = 5;
    // カメラのローカル座標（ターゲットの座標）Y軸のオフセット
    public float offset_y = 10;
    // カメラの上方向
    Vector3 up = Vector3.forward;
    
    // Start is called before the first frame update
    public void Start(GameObject _camera, GameObject _planet, GameObject _target)
    {
        camera = _camera;
        planet = _planet;
        m_target = _target;
    }

    // Update is called once per frame
    public void Update()
    {
        StartCameraMove(m_target);
        StartCameraRotation(m_target);

        time += Time.deltaTime;
        if (time > interval)
        {
            time = 0;
            panel.GetComponent<FadeController>().SetFlag(3);
        }
    }

    /// <summary>
    /// 通常カメラの移動
    /// </summary>
    void StartCameraMove(GameObject target)
    {
        // 惑星からプレイヤーまでの回転(ワールド座標に戻す用)
        Quaternion q = Quaternion.FromToRotation(Vector3.up, (target.transform.position - planet.transform.position).normalized);

        Vector3 pos = target.transform.position + (q * new Vector3(0, offset_y, 0));

        camera.transform.position = Vector3.Slerp(camera.transform.position, pos, 0.05f);
    }

    /// <summary>
    /// 通常カメラの回転
    /// </summary>
    void StartCameraRotation(GameObject target)
    {
        // ターゲットまでのベクトル
        Vector3 vec = target.transform.position - camera.transform.position;
        // 惑星までのベクトル
        Vector3 vec2 = planet.transform.position - camera.transform.position;
        // ターゲットまでのベクトルとカメラの上方向で軸を作成
        Vector3 axis = Vector3.Cross(vec, camera.transform.up);
        // 惑星までのベクトルとaxisでカメラの上方向を作成
        Vector3 up = Vector3.Cross(axis, vec2);

        camera.transform.LookAt(planet.transform.position, up);
    }
}
