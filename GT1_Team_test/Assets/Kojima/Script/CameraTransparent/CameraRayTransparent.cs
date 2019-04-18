using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayTransparent : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        float distance = Vector3.Distance(camera.transform.position, player.transform.position) * 3;
        Vector3 pos = player.transform.position + (-camera.transform.forward * distance);
        Ray ray = new Ray(pos, camera.transform.forward);

        RaycastHit[] hits = Physics.RaycastAll(ray, distance);

        foreach (RaycastHit hit in hits)
        {
            Debug.Log(hit.collider.name);
            CameraTransparentObject cameraTransparentObject = hit.collider.gameObject.GetComponent<CameraTransparentObject>();
            if (cameraTransparentObject)
            {
                cameraTransparentObject.IsTransparent = true;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    CameraTransparentObject cameraTransparentObject = other.gameObject.GetComponent<CameraTransparentObject>();
    //    if (cameraTransparentObject)
    //    {
    //        cameraTransparentObject.IsTransparent = true;
    //    }
    //}
}
