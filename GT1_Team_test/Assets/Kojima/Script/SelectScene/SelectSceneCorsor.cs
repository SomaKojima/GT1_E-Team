using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSceneCorsor : MonoBehaviour
{
    public RectTransform start;
    public RectTransform target;
    // Start is called before the first frame update
    void Start()
    {
        target = start;
        this.transform.GetComponent<RectTransform>().localPosition = start.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;
        this.transform.GetComponent<RectTransform>().localPosition = Vector3.Lerp(this.transform.GetComponent<RectTransform>().localPosition, target.localPosition, 0.1f);
    }
}
