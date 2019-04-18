using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStar : MonoBehaviour
{
    public GameObject starPrefab;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 targetPos = hit.point;
                InstanceThrowStar(targetPos);
            }
        }
    }

    void InstanceThrowStar(Vector3 targetPos)
    {
        GameObject star = Instantiate(starPrefab);
        star.transform.position = this.transform.position + this.transform.rotation * Vector3.right;
        Vector3 vec = targetPos - star.transform.position;
        Vector3 dir = this.transform.forward;
        star.GetComponent<Rigidbody>().AddForce(dir * speed);
    }
}
