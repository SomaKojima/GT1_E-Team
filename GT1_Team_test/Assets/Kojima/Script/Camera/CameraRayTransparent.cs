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
        float distance = Vector3.Distance(camera.transform.position, player.transform.position);
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);

        RaycastHit[] hits = Physics.RaycastAll(ray, distance);

        foreach (RaycastHit hit in hits)
        {
            Renderer render = hit.collider.gameObject.GetComponent<Renderer>();
            if (render)
            {
                Debug.Log(hit.collider.name);
                hit.collider.gameObject.GetComponent<Renderer>().material.color = new Color(render.material.color.r, render.material.color.g, render.material.color.b, 0.0f);
            }
        }
    }
}
