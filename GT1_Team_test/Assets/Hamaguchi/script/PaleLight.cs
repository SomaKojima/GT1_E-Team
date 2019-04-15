using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaleLight : MonoBehaviour
{
    private Vector3 aPos;
    [SerializeField]
    private GameObject lightPrefab;
    // Start is called before the first frame update
    void Start()
    {
        aPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(this.transform.position, aPos);
        if(dis>10)
        {
            GameObject obj;
            Quaternion q = Quaternion.LookRotation(Vector3.zero- aPos);
            obj = Instantiate(lightPrefab, this.transform.position, q) as GameObject;
            aPos = this.transform.position;
        }
    }
}
