using UnityEngine;

public class CoinPickup : Pickup
{
    [SerializeField] int points = 0;
    ScoreManager scoreManager;


    public void Init(ScoreManager sm)
    {
        scoreManager = sm;
    }
    protected override void OnPickup()
    {
        scoreManager.UpdateScoreUI(points);
    }

}
