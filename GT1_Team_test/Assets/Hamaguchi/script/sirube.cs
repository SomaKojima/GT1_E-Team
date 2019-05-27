using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sirube : MonoBehaviour
{

    //スタートと終わりの目印
    public Transform startMarker;
    public Transform AendMarker;
    public Transform BendMarker;
    public Transform CendMarker;

    // スピード
    public float speed = 1.0F;

    //二点間の距離を入れる
    private float distance_two;
    private Vector3 Spos;
    private Vector3 Epos;

    private float count=0.0f;

    private bool flag = false;


    void Start()
    {
        //二点間の距離を代入(スピード調整に使う)
        //Spos = startMarker;
        //Epos = endMarker;

        //distance_two = Vector3.Distance(Spos.position, Epos.position);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.position = startMarker.position;

            Spos = startMarker.position;
            Epos = AendMarker.position;

            distance_two = Vector3.Distance(Spos, Epos);

            float dis = Vector3.Distance(Spos, BendMarker.position);
            if(distance_two> dis)
            {
                Epos = BendMarker.position;
                distance_two = Vector3.Distance(Spos, Epos);
            }

            dis = Vector3.Distance(Spos, CendMarker.position);
            if (distance_two > dis)
            {
                Epos = CendMarker.position;
                distance_two = Vector3.Distance(Spos, Epos);
            }

            flag = true;

            count = 0.0f;

            transform.rotation = startMarker.rotation;



        }

        if (flag)
        {
            count += Time.deltaTime;
            // 現在の位置
            float present_Location = (count * speed) / distance_two;

            // オブジェクトの移動
            transform.position = Vector3.Slerp(Spos, Epos, present_Location);

            if(present_Location>0.99f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    public void Set()
    {
        transform.position = startMarker.position;

        Spos = startMarker.position;
        Epos = AendMarker.position;

        distance_two = Vector3.Distance(Spos, Epos);

        float dis = Vector3.Distance(Spos, BendMarker.position);
        if (distance_two > dis)
        {
            Epos = BendMarker.position;
            distance_two = Vector3.Distance(Spos, Epos);
        }

        dis = Vector3.Distance(Spos, CendMarker.position);
        if (distance_two > dis)
        {
            Epos = CendMarker.position;
            distance_two = Vector3.Distance(Spos, Epos);
        }

        flag = true;

        count = 0.0f;
    }
}