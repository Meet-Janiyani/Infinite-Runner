using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TMP_Text scoreText;

    int currentPoints = 0;
    public void UpdateScoreUI(int score)
    {
        if (gameManager.GameOver) return;

        currentPoints += score;
        scoreText.text=currentPoints.ToString();
    }
}
