using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10f; // Set the countdown time in seconds
    public float delayBeforeLoading = 7f; // Set the countdown time in seconds
    public bool timerIsRunning = false;
    public Slider timerSlider;
    public bool IsEnd = false;

    public GameObject Result;
    public TMP_Text moneyText; // Reference to the UI Text element to display money
    public int moneyEarnedInScene = 0; // Money earned in the current scene

    private void Start()
    {
        // Set the maximum value of the slider to the initial time remaining
        timerSlider.maxValue = timeRemaining;
        timerSlider.value = timeRemaining;

        // Starts the timer automatically
        timerIsRunning = true;
        IsEnd = false;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerSlider.value = timeRemaining;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if (timeRemaining == 0)
        {
            // Display the result panel
            Result.SetActive(true);
            //Time.timeScale = 0f;
            IsEnd = true;
            // Update the money text with the amount earned in the scene
            moneyText.text = moneyEarnedInScene.ToString();
        }

        if (IsEnd == true)
        {
            StartCoroutine(LoadSceneAfterDelay());
        }

    }
    public void EndDay()
    {
        SceneManager.LoadScene("Rumah");
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene("Rumah");
    }
}
