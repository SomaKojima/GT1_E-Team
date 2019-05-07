using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterLight : MonoBehaviour
{
    [SerializeField]
    private GameObject slight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<CreateOrDeleteObject>().IsPlayerSpeakBkun)
        {
            slight.SetActive(true);
        }
    }
}
