using UnityEngine;

public class FPSCapManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 70;
        QualitySettings.vSyncCount = 0;
    }
}
