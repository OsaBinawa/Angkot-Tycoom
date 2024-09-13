using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject CreditMenu;
    public GameObject mainMenu;
    public GameObject panduan;
    public bool CreditMenuOpen = false;
    public bool panduanOpen = false;


    private void Update()
    {
        if (CreditMenuOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            CreditMenu.SetActive(false);
            mainMenu.SetActive(true);
            CreditMenuOpen=false;
        }
        if (panduanOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            panduan.SetActive(false);
            mainMenu.SetActive(true);
            panduanOpen = false;
        }
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void CreditButton()
    {
        CreditMenu.SetActive(true);
        mainMenu.SetActive(false);
        CreditMenuOpen=true;
    }
    public void OpenPanduan()
    {
        panduan.SetActive(true);
        mainMenu.SetActive(false);
        panduanOpen = true;
    }

    public void BackButtom()
    { 
        CreditMenu.SetActive(false);
        mainMenu.SetActive(true);
        CreditMenuOpen = false;
    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Exit");
    }

    public void ClosePanduan()
    {
        panduan.SetActive(false);
        mainMenu.SetActive(true);
        panduanOpen = false;
    }

}
