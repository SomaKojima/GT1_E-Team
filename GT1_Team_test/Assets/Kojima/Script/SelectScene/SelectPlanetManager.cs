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

    public GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        foreach (SelectElement select in selects)
        {
            select.planet.GetComponent<Renderer>().enabled = false;
        }
        current.GetComponent<Renderer>().enabled = true;
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
                current.GetComponent<Renderer>().enabled = false;
                current = select.planet;
                current.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
