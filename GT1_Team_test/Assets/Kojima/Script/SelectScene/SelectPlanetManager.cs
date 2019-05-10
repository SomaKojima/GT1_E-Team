using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlanetManager : MonoBehaviour
{
    [System.Serializable]
    public struct SelectElement
    {
        public string name;
        public GameObject planet;
    }

    public List<SelectElement> selects = new List<SelectElement>();
    
    SelectElement currentElement;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SelectElement select in selects)
        {
            select.planet.GetComponent<Renderer>().enabled = false;
        }
        currentElement = selects[0];
        currentElement.planet.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangePlanet(string _name)
    {
        foreach (SelectElement select in selects)
        {
            if (select.name == _name)
            {
                currentElement.planet.GetComponent<Renderer>().enabled = false;
                currentElement = select;
                currentElement.planet.GetComponent<Renderer>().enabled = true;
                break;
            }
        }
    }

    public SelectElement GetCurrentSelectElement()
    {
        return currentElement;
    }
}
