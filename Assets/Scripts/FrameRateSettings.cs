using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSettings : MonoBehaviour
{
    
    void Awake()
    {
        // No vSync
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 1000;
    }


}
