using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanggePrefabs : MonoBehaviour
{
    public Money wallet;

    public List<GameObject> housePrefabs;

    private GameObject currentHouse;

    private float previousLevelRumah = -1;

    void Start()
    {
       
        ChangePrefab();
    }

    void Update()
    {
        if (wallet.LevelRumah != previousLevelRumah)
        {
            ChangePrefab();
        }
    }

    void ChangePrefab()
    {
        previousLevelRumah = wallet.LevelRumah;

        if (currentHouse != null)
        {
            Destroy(currentHouse);
        }

        int levelIndex = Mathf.Clamp((int)wallet.LevelRumah, 0, housePrefabs.Count - 1);

        currentHouse = Instantiate(housePrefabs[levelIndex], transform.position, transform.rotation);
    }
}
