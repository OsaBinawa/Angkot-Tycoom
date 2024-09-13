using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPWIN : MonoBehaviour
{
    public GameObject Rekrut;
    public GameObject Blanja;
    public GameObject Hompeg;
    public GameObject PopUp;
    public GameManager GameManager;
    public TextMeshProUGUI warningTextTMP;

    public bool BlanjaOpen;
    public bool RekrutOpen;
    public string MainMenu;
    public string Ngangkot;

    void Start()
    {
        Hompeg.SetActive(true);
        Blanja.SetActive(false);
        Rekrut.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (BlanjaOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            Blanja.SetActive(false);
            Hompeg.SetActive(true);
            BlanjaOpen = false;
        }

        if (RekrutOpen == true && Input.GetKeyUp(KeyCode.Escape))
        {
            Rekrut.SetActive(false);
            Hompeg.SetActive(true);
            RekrutOpen = false;
        }
    }

    public void OpenBlanja()
    {
        Hompeg.SetActive(false);
        Blanja.SetActive(true);
        BlanjaOpen = true;
    }

    public void OpenRek()
    {
        Hompeg.SetActive(false);
        Rekrut.SetActive(true);
        RekrutOpen = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    public void GoToNgangkot() 
    {
        if (GameManager.Gas == true)
        {
            SceneManager.LoadScene(Ngangkot);
        }
        else
        {
            Debug.Log("No Gas");
            StartCoroutine(ShowWarningText());
        }
        
    }

    private IEnumerator ShowWarningText()
    {
        // Activate the warning text
        warningTextTMP.gameObject.SetActive(true);
        warningTextTMP.text = "No Gas!"; // Set the warning message

        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // Deactivate the warning text
        warningTextTMP.gameObject.SetActive(false);
    }

    public void PopUps()
    {
        PopUp.SetActive(true);
    }
}
