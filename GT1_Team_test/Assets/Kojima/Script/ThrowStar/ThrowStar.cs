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

        // 追加--------------------------------------------------------
        
        // 星のデータ
        StarDate stardate = star.GetComponent<StarDate>();
        // 星を投げるフラグを付ける
        stardate.IsThrow = true;

        //--------------------------------------------------------------


        Vector3 pos = this.transform.position + this.transform.right;
        star.transform.position = pos;
        Vector3 vec = targetPos - pos;
        star.GetComponent<Rigidbody>().velocity = vec.normalized * speed;
        Debug.Log(vec.normalized * speed);
    }
}
