using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; 
    private int score = 0; 

    
    public void IncreaseScore()
    {
        score++; 
        UpdateScoreText(); 
    }

    
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString(); 
    }
}


