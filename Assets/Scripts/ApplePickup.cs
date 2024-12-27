using UnityEngine;

public class ApplePickup : Pickup
{
    [SerializeField] float speedBoost = 2f;
    ProceduralGeneration pg;

    public void Init(ProceduralGeneration pg)
    {
        this.pg = pg;
    }
    protected override void OnPickup()
    {
        pg.ChangeMoveSpeed(speedBoost);
    }
}
