using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] ProceduralGeneration pg;
    [SerializeField] CameraController cc;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] Transform chunkParent;
    [SerializeField] int totalChunks=12;
    [SerializeField] int chunkScale=10;
    [SerializeField] float moveSpeed=10f;
    [SerializeField] float minMoveSpeed = 2f;
    [SerializeField] float maxMoveSpeed = 14f;
    [SerializeField] float minGravity = -2f;
    [SerializeField] float maxGrvaity = 20f;


    List<GameObject> chunks=new List<GameObject>();
    int chunksGenerated = 0;
    void Start()
    {
        GenerateChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    private void MoveChunks()
    {
        for (int i=0;i<chunks.Count;i++)
        {
            GameObject chunk = chunks[i];   
            chunk.transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkScale)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                Vector3 spawnPosition = chunks[chunks.Count-1].transform.position+new Vector3(0,0,chunkScale);
                int randomChunk=Random.Range(0,chunkPrefabs.Length-1);
                if (chunksGenerated % 8 == 0) randomChunk = chunkPrefabs.Length-1;
                GameObject newChunk = Instantiate(chunkPrefabs[randomChunk], spawnPosition, Quaternion.identity, chunkParent);
                chunksGenerated++;
                newChunk.GetComponent<Chunk>().InitScoreManager(scoreManager);
                newChunk.GetComponent<Chunk>().InitProceduralGenerator(pg);
                chunks.Add(newChunk);
            }
        }
    }

    private void GenerateChunks()
    {
        for (int i = 0; i < totalChunks; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(0, 0, transform.position.z + i * chunkScale);
            int randomChunk = Random.Range(0, chunkPrefabs.Length - 1);
            if (chunksGenerated % 8 == 0) randomChunk = chunkPrefabs.Length - 1;
            GameObject chunk= Instantiate(chunkPrefabs[randomChunk], spawnPosition, Quaternion.identity, chunkParent);
            chunksGenerated++;
            chunk.GetComponent<Chunk>().InitProceduralGenerator(pg);
            chunk.GetComponent<Chunk>().InitScoreManager(scoreManager);
            chunks.Add(chunk);

        }
    }

    public void ChangeMoveSpeed(float speed)
    {
        moveSpeed += speed;
        moveSpeed=Mathf.Clamp(moveSpeed, minMoveSpeed, maxMoveSpeed);
        cc.ChangeCameraFOV(speed);
        float zGravity = Mathf.Clamp(Physics.gravity.z-moveSpeed,minGravity,maxGrvaity);
        Physics.gravity=new Vector3(Physics.gravity.x,Physics.gravity.y,Physics.gravity.z-moveSpeed);
    }
}
