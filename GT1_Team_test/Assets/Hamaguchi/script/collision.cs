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
    private bool dustFlag = false;
    private bool clear = false;
    private bool talkFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (clear)
        {
            slight.spotAngle++;
        }
        else
        {
            slight.spotAngle = (dustCounter + 2) * lightPower;
        }


        if (dustFlag)
        {
            dustCounter++;
            dustFlag = false;
        }

        float dis = Vector3.Distance(this.transform.position, Vector3.zero);
        if(dis<40.0f)
        {
            this.transform.position = startPos;
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            dustCounter -= 3;
            if(dustCounter<0)
            {
                dustCounter = 0;
            }
            Debug.Log("penalty"); // ログを表示する
        }

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dust")
        {
            dustFlag = true;
            Destroy(collision.gameObject);
            //Debug.Log(dustCounter); // ログを表示する
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "area")
        {
            talkFlag = col.gameObject.GetComponent<talk>().GetFlag();
        }
    }

    public void SetFlagA()
    {
        flagA = true;
    }

    public bool GetFlagA()
    {
        return flagA;
    }

    public int GetDustCount()
    {
        return dustCounter;
    }

    public void Clear()
    {
        clear = true;
    }

    public bool GetTalkFlag()
    {
        return talkFlag;
    }
}
