using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static UpgradeSystem instance;
    public Money money;
    public GameObject[] upgradePrefabs; // Array of prefabs for different upgrade levels
    public Transform spawnPoint; // The location and rotation where the new prefab will be instantiated

    public int currentLevel = 0; // To keep track of the current upgrade level
    private GameObject currentObject; // Reference to the current active object

    [SerializeField]
    public float canBuyAngkot = 0f;
    // Start is called before the first frame update
    void Start()
    {
        money.LevelRumah = currentLevel;
        // Initialize with the first prefab using the spawn point's rotation
        currentObject = Instantiate(upgradePrefabs[currentLevel], spawnPoint.position, spawnPoint.rotation);
    }

    // This function is called when the upgrade button is clicked
    public void Upgrade()
    {
        if (money.amount >= 100000)
        {
            if (currentLevel + 1 < upgradePrefabs.Length)
            {
                currentLevel++; // Increment the upgrade level

                // Destroy the current object
                Destroy(currentObject);

                // Instantiate the new object with the spawn point's position and rotation
                currentObject = Instantiate(upgradePrefabs[currentLevel], spawnPoint.position, spawnPoint.rotation);

                money.amount -= 100000;
                money.LevelRumah += 1;
                canBuyAngkot += 1f;
            }
            else
            {
                Debug.Log("Max upgrade level reached.");
            }
        }
        // Check if there is a next level
        
    }
}
