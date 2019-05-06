using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStar : MonoBehaviour
{
    public Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(vel);
    }
}
