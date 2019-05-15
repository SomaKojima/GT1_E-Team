using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SelectPlanetName : MonoBehaviour
{
    SelectPlanetManager selectPlanetManager;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        selectPlanetManager = GameObject.Find("SelectPlanetManager").GetComponent<SelectPlanetManager>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = selectPlanetManager.GetCurrentSelectElement().name;
    }
}
