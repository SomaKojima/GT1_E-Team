using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    Rigidbody rigid;

    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float MaxSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            vel.z = speed;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.S))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel.x = -speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vel.z = -speed;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.rotation *= Quaternion.AngleAxis(-3.0f, Vector3.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.rotation *= Quaternion.AngleAxis(3.0f, Vector3.up);
        }

        //vel = transform.rotation * vel;
        //this.transform.Translate(vel);
        float dist = rigid.velocity.magnitude;
        //if (dist < MaxSpeed)
        {
            rigid.AddForce(this.transform.rotation * vel);
        }

    }
}
