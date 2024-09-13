using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "TimerData", menuName = "ScriptableObjects/TimerData", order = 1)]
public class TimerData : ScriptableObject   
{
    public float timeRemaining;
    public float maxTime; 
    
    public void HEHE()
    {
        timeRemaining = maxTime;
    }
}
