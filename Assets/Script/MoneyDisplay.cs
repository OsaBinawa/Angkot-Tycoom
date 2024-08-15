using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public Money money;
    public TMP_Text moneyDisplay;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }


   public void UpdateDisplay()
    {
        moneyDisplay.text = money.amount.ToString();
    }
}
