using UnityEngine;
using TMPro;

public class FPSManager : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    
    float frames;
    float timer;

    // For calculating FPS and showing on the screen
    void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        if(timer >= 1f){
            int fps = (int)(frames / timer);
            fpsText.text = fps.ToString() + " FPS";

            frames = 0;
            timer = 0;
        }
    } 
}
