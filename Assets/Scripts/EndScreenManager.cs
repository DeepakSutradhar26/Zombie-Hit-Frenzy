using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // For Endscreen to pop up on screen
    public void SetUp(int score){
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS";
    }

    // Restart button logic
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }
}
