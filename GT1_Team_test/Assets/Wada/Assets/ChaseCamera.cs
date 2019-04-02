using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    public GameObject traget;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - traget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = traget.transform.position + offset;
    }
}
