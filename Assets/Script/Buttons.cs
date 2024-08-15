using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public UpgradeSystem upgradeSystem;
    public Money money;

    private void Start()
    {
       
    }
    public void OnUpgradeButtonClicked()
    {
        upgradeSystem.Upgrade();
    }

    public void MoneyCheats()
    {
        money.amount += 100;
    }
}
