using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTrigerEnter(Collision collision)
    {
        if (collision.gameObject.tag == "area")
        {
            Debug.Log("talk.OK"); // ログを表示する
        }
    }
}
