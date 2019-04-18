using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransparentObject : MonoBehaviour
{
    const float ALPHA_SPEED = 0.1f;
    const float ALPHA_MIN = 0.1f;

    // 透明にするかどうかのフラグ
    bool isTransparent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTransparent)
        {
            foreach (Material material in this.gameObject.GetComponent<Renderer>().materials)
            {
                BlendModeUtils.SetBlendMode(material, BlendModeUtils.Mode.Fade);
                // 色を透明にする

                float alpha = material.color.a;
                if (alpha > ALPHA_MIN) alpha -= ALPHA_SPEED;
                else alpha = ALPHA_MIN;
                material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
            }
        }
        else
        {
            foreach (Material material in this.gameObject.GetComponent<Renderer>().materials)
            {
                // 色を元に戻す

                float alpha = material.color.a;
                if (alpha < 1.0f) alpha += ALPHA_SPEED;
                else
                {
                    alpha = 1.0f;
                    material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
                    BlendModeUtils.SetBlendMode(material, BlendModeUtils.Mode.Opaque);
                }
                material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);
                
            }
        }
        isTransparent = false;
    }

    public bool IsTransparent
    {
        set { isTransparent = value; }
    }
}
