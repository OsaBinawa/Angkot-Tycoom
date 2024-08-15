using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool Gas = false;
    public float LevelAngkot = 1f;
    public Money jumlahAngkot;

    public GameObject Angkot2;
    public GameObject Angkot3;
    public GameObject Angkot4;
    //public GameObject StartButton;
    void Start()
    {
        Gas = false;
        Angkot2.gameObject.SetActive(false);
        //Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Gas == true)
        // { StartButton.S}

        //Debug.Log(Gas);
        if (Angkot2 != null && Angkot3 != null && Angkot4 != null)
        {
            if (jumlahAngkot.jumlahAngkot == 2)
            {
                Angkot2.gameObject.SetActive(true);
            }

            if (jumlahAngkot.jumlahAngkot == 3)
            {
                Angkot3.gameObject.SetActive(true);
            }

            if (jumlahAngkot.jumlahAngkot == 4)
            {
                Angkot4.gameObject.SetActive(true);
            }
        }
        
    }
}
