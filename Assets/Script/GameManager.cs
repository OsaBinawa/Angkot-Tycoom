using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Gas = false;
    public float LevelAngkot = 1f;
    public Money jumlahAngkot;
    public TimerData timerData;

    public GameObject Angkot2;
    public GameObject Angkot3;
    public GameObject Angkot4;
    public GameObject Angkot5;
    //public GameObject StartButton;

    private void Awake()
    {
        Time.timeScale = 1f;
    }
    void Start()
    {
        Time.timeScale = 1f;
        Gas = false;
        Angkot2.gameObject.SetActive(false);
        //Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerData.timeRemaining != 0)
        {
            Gas = true;
        }
        else
        {
            Gas = false;
        }

        //Debug.Log(Gas);
        if (Angkot2 != null && Angkot3 != null && Angkot4 != null)
        {
            if (jumlahAngkot.jumlahAngkot == 2 && jumlahAngkot.Driver == 2)
            {
                Angkot2.gameObject.SetActive(true);
            }

            if (jumlahAngkot.jumlahAngkot == 3 && jumlahAngkot.Driver == 3)
            {
                Angkot3.gameObject.SetActive(true);
            }

            if (jumlahAngkot.jumlahAngkot == 4 && jumlahAngkot.Driver == 4)
            {
                Angkot4.gameObject.SetActive(true);
            }
            if (jumlahAngkot.jumlahAngkot == 5 && jumlahAngkot.Driver == 5)
            {
                Angkot5.gameObject.SetActive(true);
            }
        }
        
    }
}
