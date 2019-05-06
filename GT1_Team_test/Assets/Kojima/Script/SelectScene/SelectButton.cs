using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectButton : MonoBehaviour
{
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // マウスカーソルが入った
    public void OnPointerEnter()
    {
        GameObject.Find("SelectPlanetManager").GetComponent<SelectPlanetManager>().ChangePlanet(name);
    }
}
