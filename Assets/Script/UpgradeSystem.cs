using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public GameObject[] upgradePrefabs; // Assign your upgrade prefabs in the inspector
    private int currentLevel = 0;
    private GameObject currentUpgrade;

    void Start()
    {
        ApplyUpgrade(0); // Initialize with the first level
    }

    public void Upgrade()
    {
        if (currentLevel < upgradePrefabs.Length - 1)
        {
            currentLevel++;
            ApplyUpgrade(currentLevel);
        }
    }

    void ApplyUpgrade(int level)
    {
        if (currentUpgrade != null)
        {
            Destroy(currentUpgrade);
        }

        currentUpgrade = Instantiate(upgradePrefabs[level], transform.position, transform.rotation, transform);
    }
}
