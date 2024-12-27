using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float timeToAdd = 5f;
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.UpdateRemainingTime(timeToAdd);
        }
    }
}
