using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameCont : MonoBehaviour
{

    /// <summary>
    /// カメラのターゲット    
    /// </summary>
    public GameObject target;

    public float distance = 10;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion q = Quaternion.Inverse(target.transform.rotation);
        Vector3 vec = target.transform.position - this.transform.position;
        vec.y = 0;
        //vec = q * vec;
        float length = vec.magnitude;
        Vector3 vec_normal = vec.normalized;

        Debug.Log(length);

        // カメラの距離が遠い場合
        if (distance < length)
        {
            float move_length = length - distance;
            // ターゲットに向けて移動
            Vector3 move_vec = vec_normal * move_length;
            
            //move_vec = target.transform.rotation * move_vec;
            this.transform.position += move_vec;
        }

        //Vector3 offset_pos = target.transform.position + (target.transform.rotation * offset);
        //this.transform.position = new Vector3(this.transform.position.x, offset_pos.y, this.transform.position.z);
        this.transform.LookAt(target.transform.position, target.transform.up);
    }
}
