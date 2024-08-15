using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public GameManager manager;
    public TMP_Text debugText;  // Reference to the TMP_Text component
    public float messageDuration = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Goterminal()
    {
        if (manager.Gas == true)
        {
            SceneManager.LoadScene("Terminal");
        }
        else
        {
            Debug.Log("NoGas");
            StartCoroutine(DisplayMessage("No Gas", messageDuration));
        }
    }

    private IEnumerator DisplayMessage(string message, float duration)
    {
        debugText.text = message;
        yield return new WaitForSeconds(duration);
        debugText.text = "";
    }
}
