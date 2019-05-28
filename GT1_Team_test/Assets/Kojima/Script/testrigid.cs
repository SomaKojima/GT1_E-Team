using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testrigid : MonoBehaviour
{
    public Rigidbody rigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = rigid.velocity;

        this.transform.rotation = Quaternion.FromToRotation(Vector3.forward, vec.normalized);
    }
}
