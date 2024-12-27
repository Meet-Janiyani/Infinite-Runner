using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] obstacle;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float obstacleSpawnTime=2f;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int randomObstacle = Random.Range(0, obstacle.Length);
            Instantiate(obstacle[randomObstacle], transform.position, Random.rotation,obstacleParent);
            yield return new WaitForSeconds(obstacleSpawnTime);
        }
    }


}
