using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStarEffect : MonoBehaviour
{
    public float _anglePerFrame = 0.1f;    // 1フレームに何度回すか[unit : deg]
    float _rot = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // 回す
        transform.Rotate(new Vector3(0.0f, _anglePerFrame,0.0f));
    }
}
