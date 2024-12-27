using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.4f;

    List<int> laneList = new List<int> { 0, 1, 2 };
    float[] lanes = {-2.5f,0f,2.5f };

    ProceduralGeneration pg;
    ScoreManager scoreManager;

    void Start()
    {
        SpawnFence();
        SpawnCollectibles();
    }

    private void SpawnFence()
    {
        int fenceToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fenceToSpawn; i++)
        {
            if (laneList.Count <= 0) return;
            int randomLane = SelectLane();
            Vector3 spawnPosition = new Vector3(lanes[randomLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);

        }
    }

    private int SelectLane()
    {
        int randomLane = Random.Range(0, laneList.Count);
        int selectedLane = laneList[randomLane];
        laneList.RemoveAt(randomLane);
        return selectedLane;
    }

    void SpawnCollectibles()
    {
        if (Random.value > appleSpawnChance || laneList.Count <= 0  ) return;
        int randomLane = SelectLane();
        Vector3 spawnPosition = new Vector3(lanes[randomLane], transform.position.y, transform.position.z);
        GameObject apple= Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform);
        apple.GetComponent<ApplePickup>().Init(pg);

        if (Random.value > coinSpawnChance) return;
        int applesToSpawn=Random.Range(0, 5);
        for (int i = 0; i < applesToSpawn; i++)
        {
            Vector3 coinSpawnPosition = new Vector3(lanes[randomLane], transform.position.y, transform.position.z + (i + 1) * 1f);
            GameObject coin= Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity, this.transform);
            coin.GetComponent<CoinPickup>().Init(scoreManager);
        }
    }

    public void InitProceduralGenerator(ProceduralGeneration pg)
    {
        this.pg = pg;
    }

    public void InitScoreManager(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }
}
