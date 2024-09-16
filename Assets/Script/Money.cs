using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "Wallet", menuName = "Wallet")]
public class Money : ScriptableObject
{
    [SerializeField]
    public float amount;
    public float jumlahAngkot;
    public float Driver;
    public int LevelRumah;
}
