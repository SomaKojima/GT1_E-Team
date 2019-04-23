using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class wishList : MonoBehaviour
{
    private float x, y;  //変更したいサイズ

    // Start is called before the first frame update
    void Start()
    {
        x = this.GetComponent<RectTransform>().sizeDelta.x;
        y = this.GetComponent<RectTransform>().sizeDelta.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);

        float changeRed = 0.7f;
        float changeGreen = 0.7f;
        float cahngeBlue = 0.7f;
        // 元の画像がそのまま表示される。
        this.GetComponent<Image>().color = new Color(changeRed, changeGreen, cahngeBlue);

        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, result);

        foreach (RaycastResult raycastResult in result)
        {
            // 反応したパネルの名前を表示
            Debug.Log(raycastResult.gameObject.name);
            if (raycastResult.gameObject.name == this.gameObject.name)
            {
                changeRed = 1.0f;
                changeGreen = 1.0f;
                cahngeBlue = 1.0f;
                this.GetComponent<Image>().color = new Color(changeRed, changeGreen, cahngeBlue);
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(x + 40, y + 20);
            }
        }
    }
}