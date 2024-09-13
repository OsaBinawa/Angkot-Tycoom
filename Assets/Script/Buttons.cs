using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public UpgradeSystem buildingManager; // Reference to the BuildingManager script

    void Start()
    {
        // Get the button component and add a listener to call the Upgrade method when clicked
        //GetComponent<Button>().onClick.AddListener(buildingManager.UpgradeBuilding);
    }
}
