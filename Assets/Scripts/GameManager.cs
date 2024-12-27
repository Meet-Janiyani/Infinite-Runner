using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerInput pi;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime=10f;

    bool gameOver = false;
    public bool GameOver {  get { return gameOver; }  }
    float remainingTime = 0;

    private void Start()
    {
        remainingTime = startTime;
    }


    void Update()
    {
        if (gameOver) return;
        
        remainingTime -=Time.deltaTime;
        timeText.text=remainingTime.ToString("F1");
        if (remainingTime < 0.0f)
        {
            gameOver = true;
            gameOverText.SetActive(true);
            Time.timeScale = 0.1f;
            pi.enabled = false;
        }
    }

    public void UpdateRemainingTime(float timeAmount)
    {
        remainingTime += timeAmount;
    }
}
