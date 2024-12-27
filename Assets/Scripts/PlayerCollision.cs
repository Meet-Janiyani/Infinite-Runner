using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float speedReduction;

    ProceduralGeneration pg;
    bool isStumbling = false;

    private void Start()
    {
        pg = FindFirstObjectByType<ProceduralGeneration>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Obstacle" && !isStumbling)
        {
            StopAllCoroutines();
            StartCoroutine(StumbleRoutine());
        }
    }

    IEnumerator StumbleRoutine()
    {
        pg.ChangeMoveSpeed(speedReduction);
        animator.SetTrigger("Stumble");
        isStumbling=true;
        yield return new WaitForSeconds(1f);
        isStumbling = false;
    }

}
