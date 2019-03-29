using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostureController : MonoBehaviour
{

    [SerializeField]
    GameObject center;

    [SerializeField]
    GameObject demo;

    GameObject[] planets;

    GameObject targetPlanet;

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        if (!targetPlanet) return;
        // 姿勢制御
        // 自身からターゲットの惑星までのベクトル
        Vector3 vec = this.transform.position - targetPlanet.transform.position;
        Vector3 vecNormal = vec.normalized;

        Quaternion q = Quaternion.identity;
        q = Quaternion.FromToRotation(transform.up, vecNormal);

        this.transform.rotation = q * this.transform.rotation;
        
    }

    private void OnTriggerStay(Collider other)
    {
        // 一番近い惑星を更新
        if (other.name == "PostureCollision")
        {
            targetPlanet = other.transform.parent.gameObject;
        }
    }
}
