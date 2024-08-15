using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Array of NPC prefabs
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;
    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnNPC();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnNPC()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int prefabIndex = Random.Range(0, npcPrefabs.Length);
        Instantiate(npcPrefabs[prefabIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
