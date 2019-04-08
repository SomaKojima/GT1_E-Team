using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    [SerializeField]
    private int lightPower = 2;
    [SerializeField]
    private Light slight;

    private int dustCounter = 0;
    private bool flagA = false;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        slight.spotAngle = (dustCounter + 2) * lightPower;

        float dis = Vector3.Distance(this.transform.position, Vector3.zero);
        if(dis<40.0f)
        {
            this.transform.position = startPos;
            Debug.Log("penalty"); // ログを表示する
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dust")
        {
            Destroy(collision.gameObject);
            dustCounter++;
            Debug.Log(dustCounter); // ログを表示する
        }
    }

    public void SetTalkFlag()
    {
        flagA = true;
    }

    public bool GetTalkFlag()
    {
        return flagA;
    }

    public int GetDustCount()
    {
        return dustCounter;
    }
}
