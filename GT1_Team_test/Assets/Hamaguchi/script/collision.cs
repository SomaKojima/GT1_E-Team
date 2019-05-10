using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class collision : MonoBehaviour
{
    [SerializeField]
    private int lightPower = 2;
    [SerializeField]
    private Light slight;
    [SerializeField]
    private int dustCounter = 3;
    private bool flagA = false;
    private bool flagB = false;
    private bool flagC = false;
    private Vector3 startPos;
    private bool dustFlag = false;
    private bool clear = false;
    private bool talkFlag = false;
    private float rightTime = 10.0f;
    private float rimitTime = 5.0f;
    private float restartTime = 0.0f;

    private GameObject target = null;

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
            //slight.spotAngle = (dustCounter + 2) * lightPower;
            rightTime += Time.deltaTime;
            slight.spotAngle = 27.0f;
            if (rightTime>10.0f)
            {
                rightTime = 10.0f;
                rimitTime += Time.deltaTime;
                slight.spotAngle = 15.0f;
                if (rimitTime<2.0f)
                {
                    slight.spotAngle = 27.0f - (12.0f * (rimitTime / 2.0f));
                }                
            }
        }


        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, result);

        restartTime += Time.deltaTime;
        if (restartTime > 5.0f)
        {
            //if ()
            {
                restartTime = 0;
                startPos = this.transform.position;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            foreach (RaycastResult raycastResult in result)
            {
                if (raycastResult.gameObject.name == "board1")
                {
                    if (dustCounter > 2)
                    {
                        rimitTime = 0;
                        rightTime = 0;
                        dustCounter-=3;
                    }
                }
            }
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
            restartTime = 0;
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
            target = col.gameObject;
        }
        if (col.gameObject.tag == "Light")
        {
            slight.intensity = 0;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Light")
        {
            slight.intensity = 5;
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

    public void SetFlagB()
    {
        flagB = true;
    }

    public bool GetFlagB()
    {
        return flagB;
    }

    public void SetFlagC()
    {
        flagC = true;
    }

    public bool GetFlagC()
    {
        return flagC;
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

    public GameObject GetTarget()
    {
        return target;
    }
}
