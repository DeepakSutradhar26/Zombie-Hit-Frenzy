using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;

    public int score = 0;
    
    // Update score only if their is change in score
    public void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame
    public void AddPoints()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }
}
