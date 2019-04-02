using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField]
    private int lightPower = 2;
    public int dustCounter;
    private Light light;
    // Start is called before the first frame update
    void Start()
    {
        dustCounter = 0;
        light = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dust")
        {
            Destroy(collision.gameObject);
            dustCounter++;
            Debug.Log(dustCounter); // ログを表示する
            light.range = (dustCounter + 1) * lightPower;
        }
    }
}
