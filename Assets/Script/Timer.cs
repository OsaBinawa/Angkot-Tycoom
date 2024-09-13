using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TimerData timerData; // Reference to the TimerData ScriptableObject
    public float delayBeforeLoading = 7f; // Delay before loading the new scene
    public bool timerIsRunning = false;
    public Slider timerSlider;
    public bool IsEnd = false;

    public GameObject Result;
    public TMP_Text moneyText; // Reference to the UI Text element to display money
    public int moneyEarnedInScene = 0; // Money earned in the current scene

    private void Start()
    {
        if (timerData != null)
        {
            // Initialize the slider with values from TimerData
            timerSlider.maxValue = timerData.maxTime;
            timerSlider.value = timerData.timeRemaining;

            // Starts the timer
            timerIsRunning = true;
            IsEnd = false;
        }
        else
        {
            Debug.LogError("TimerData is not assigned.");
        }
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timerData.timeRemaining > 0)
            {
                timerData.timeRemaining -= Time.deltaTime;
                timerSlider.value = timerData.timeRemaining;
            }
            else
            {
                timerData.timeRemaining = 0;
                timerIsRunning = false;
                HandleTimerEnd();
            }
        }
    }

    private void HandleTimerEnd()
    {
        // Display the result panel and update money text
        Result.SetActive(true);
        moneyText.text = moneyEarnedInScene.ToString();
        IsEnd = true;

        // Start the scene transition coroutine
        StartCoroutine(LoadSceneAfterDelay());
    }

    public void EndDay()
    {
        // Immediately load the new scene
        SceneManager.LoadScene("Rumah");
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoading);
        SceneManager.LoadScene("Rumah");
    }
}
