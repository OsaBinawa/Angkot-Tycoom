using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Array of NPC prefabs
    public Transform[] spawnPoints;
    public GameObject path; // Reference to the path GameObject
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

        // Instantiate the NPC at the chosen spawn point
        GameObject npc = Instantiate(npcPrefabs[prefabIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

        // Set the path for NPCMove component if it exists
        NPCMove npcMove = npc.GetComponent<NPCMove>();
        if (npcMove != null && path != null)
        {
            npcMove.PATH = path; // Assign the path GameObject to the NPCMove script
        }
    }
}
