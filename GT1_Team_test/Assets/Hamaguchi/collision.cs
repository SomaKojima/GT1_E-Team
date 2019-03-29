using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    int dustCounter;
    // Start is called before the first frame update
    void Start()
    {
        dustCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dust")
        {
            Destroy(collision.gameObject);
            dustCounter++;
            Debug.Log(dustCounter); // ログを表示する
        }
    }
}
