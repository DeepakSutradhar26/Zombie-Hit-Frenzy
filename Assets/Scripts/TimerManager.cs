using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public EndScreenManager endScreen;
    public TextMeshProUGUI timerText;

    public SimpleJoystick joystick;

    public float timer = 60f;

    public bool gameEnded = false;

    // Update is called once per frame
    // If timer ends, show end screen
    void Update()
    {
        if(gameEnded) return;
        if(timer <= 0f){
            timer = 0f;
            gameEnded = true;
            endScreen.SetUp(scoreManager.score);

            if(joystick != null){
                joystick.ResetJoystick();
                joystick.enabled = false;
            }
        }
        if(timer > 0f){
            timer -= Time.deltaTime;
            int displayTimer = Mathf.CeilToInt(timer);
            timerText.text = displayTimer.ToString();
        }
    }
}
