using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkCamera
{
    // カメラ
    GameObject camera;

    // 話しかける時の位置
    public Transform pos;
    // 話しかける相手
    public Transform target;
    // プレイヤー
    public GameObject player;


    // Start is called before the first frame update
    public void Start(GameObject _camera, Transform _pos, Transform _target, GameObject _player)
    {
        camera = _camera;
        pos = _pos;
        target = _target;
        player = _player;
    }

    // Update is called once per frame
    public void Update()
    {

        TalkCameraMove();
        TalkCameraRotation();
    }

    /// <summary>
    /// 話す用のカメラの動き
    /// </summary>
    void TalkCameraMove()
    {
        if (!pos) return;
        camera.transform.position = Vector3.Lerp(camera.transform.position, pos.position, 0.1f);
    }

    /// <summary>
    /// 話す用のカメラの回転
    /// </summary>
    void TalkCameraRotation()
    {
        if (!target) return;
        camera.transform.LookAt(target.position, player.transform.up);
    }
}
