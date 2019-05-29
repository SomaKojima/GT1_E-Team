using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGMを鳴らす
/// </summary>
public class BGMSound : MonoBehaviour
{
    // BGM名
    public string BGM_Name;

    // Start is called before the first frame update
    void Start()
    {
        // 音を鳴らす
        SoundManager.Instance.PlayBgm(BGM_Name);

    }

}
