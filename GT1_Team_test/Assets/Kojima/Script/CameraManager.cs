using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform _cameraParent;
    private Transform _cameraChild;
    private Transform _camera;

    /// <summary>
    /// 注視対象
    /// 座標をCameraParentの座標に代入
    /// </summary>
    public Transform LookTarget;

    /// <summary>
    /// 注視点からの距離（CameraChildのローカルZ座標）
    /// </summary>
    public float Distance;

    /// <summary>
    /// 注視点への回り込み角度（CameraParentの角度）
    /// </summary>
    public Vector3 LookAngles;

    /// <summary>
    /// 視界オフセット座標（Main Cameraのローカル座標）
    /// </summary>
    public Vector2 OffsetPosition;

    void Start()
    {
        _cameraParent = transform;
        _cameraChild = _cameraParent.GetChild(0);
        _camera = _cameraChild.GetChild(0);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _cameraParent.position = Vector3.Lerp(_cameraParent.position, LookTarget.position, 0.1f);
        _cameraChild.localPosition = new Vector3(0, 0, -Distance); // 負数にする
        _cameraParent.eulerAngles = LookAngles + LookTarget.eulerAngles;
        _camera.localPosition = OffsetPosition;
    }
}
