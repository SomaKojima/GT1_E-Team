using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    float angle = 0;
    bool isSlow = false;
    Quaternion start;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        angle += 1.5f;
        if (angle >= 360.0f)
        {
            isSlow = !isSlow;
            angle = 0;
        }
        transform.rotation = start * Quaternion.AngleAxis(angle, Vector3.up);
    }
}
