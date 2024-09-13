using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public HPWIN hpwin;
    public GameObject shopWin;
    //public GameObject UI;
    public Button UIHire;
    public Button BuyAngkots;
    public Money Money;
    public GameManager Manager;
    public Slider quantitySlider;
    public TMP_Text quantityText;
    public TMP_Text jumlahAngkotText;
    public TMP_Text driverText;
    public TimerData timerData;
    public float needDriver = 0f;
    public bool _needDriver;

    public float itemPrice = 10f;

    public bool ShopWinOpen = false;
    public UpgradeSystem upgrade;

    void Start()
    {
        //shopWin.SetActive(false);
        quantitySlider.minValue = 150;  // Example minimum value
        quantitySlider.maxValue = 1000; // Example maximum value
        quantitySlider.value = 150;    // Starting value (for example)

        // Add listener for slider value changes
        quantitySlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Initialize text display
        UpdateQuantityText();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopWinOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            shopWin.SetActive(false);
            //UI.SetActive(true);
            ShopWinOpen = false;
        }

        if (upgrade.canBuyAngkot !=0)
        {
            BuyAngkots.enabled = true;
        }
        else
        {
            BuyAngkots.enabled=false;
        }

        if (needDriver !=0)
        {
            UIHire.enabled = true;
            
        }
        else
        {
            UIHire.enabled = false;
        }

        if (timerData != null)
        {
            // Example: Check if time is up and update UI or shop state
            if (timerData.timeRemaining <= 0)
            {
                // Timer expired logic (e.g., disable purchase or show a message)
            }
        }
        UpdateUI();
    }

    private void OnSliderValueChanged(float value)
    {
        // Update quantity display and other logic
        UpdateQuantityText();
    }

    private void UpdateQuantityText()
    {
        if (quantityText != null)
        {
            int quantity = Mathf.RoundToInt(quantitySlider.value);
            quantityText.text = "Quantity: " + quantity / 60 + " Liter" + "\nTotal Price: " + CalculateTotalPrice();
        }
    }

    public float CalculateTotalPrice()
    {
        float quantity = Mathf.RoundToInt(quantitySlider.value);
        return quantity * itemPrice;
    }

    public void PurchaseItems()
    {
        float totalPrice = CalculateTotalPrice();
        if (Money != null && Money.amount >= totalPrice)
        {
            Money.amount -= totalPrice;
            Debug.Log("Purchase successful! Remaining balance: " + Money.amount);

            // Update timerData.timeRemaining based on slider value after successful purchase
            if (timerData != null)
            {
                timerData.timeRemaining = quantitySlider.value;
                timerData.maxTime = quantitySlider.value;
                // Update timerData with slider value
            }
            hpwin.PopUp.SetActive(false);
        }
        else
        {
            Debug.Log("Insufficient funds!");
        }
    }

    public void BuyAngkot()
    {
        if (Money.amount >= 100000)
        {
            Money.jumlahAngkot += 1;
            Money.amount -= 100000;
            needDriver += 1;
            upgrade.canBuyAngkot -= 1;
        }
        else
        {
            Debug.Log("No Money");
        }
    }

    public void HireDriver()
    {
        if (Money.amount >= 10000)
        {
            Money.Driver += 1;
            Money.amount -= 10000;
            needDriver -= 1;
        }
        else
        {
            Debug.Log("No Money");
        }
    }

    public void UpdateUI()
    {
        jumlahAngkotText.text =  Money.jumlahAngkot.ToString();
        driverText.text = Money.Driver.ToString();
    }

}
