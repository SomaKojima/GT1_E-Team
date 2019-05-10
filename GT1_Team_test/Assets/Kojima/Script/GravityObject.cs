using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    [System.Serializable]
    public struct GravityStatus
    { 
        public float mass;

        public GravityStatus(float mass)
        {
            this.mass = mass;
        }
    }

    public GravityStatus status = new GravityStatus(1.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
