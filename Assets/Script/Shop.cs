using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopWin;
    public GameObject UI;
    public Money Money;
    //public Money jumlahAngkot;
    public GameManager Manager;

    public bool ShopWinOpen = false;

    void Start()
    {
        shopWin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopWinOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            shopWin.SetActive(false);
            UI.SetActive(true);
            ShopWinOpen = false;
        }
    }

    public void BuyGas()
    {
        if (Money.amount >= 2000)
        {
            Manager.Gas = true;
            Money.amount -= 2000;
        }
        else
        {
            Debug.Log("LU MISKIN");
        }
       
    }

    public void BuyAngkot()
    {
        if (Money.amount >= 2000)
        {
            Money.jumlahAngkot += 1;
            Money.amount -= 2000;
        }
        else
        {
            Debug.Log("LU MISKIN");
        }

    }

    public void OpenShop()
    {
        shopWin.SetActive(true);
        UI.SetActive(false);
        ShopWinOpen = true;
    }

    public void CloseShop() 
    {
        shopWin.SetActive(false);
        UI.SetActive(true);
        ShopWinOpen = false;
    }
}
