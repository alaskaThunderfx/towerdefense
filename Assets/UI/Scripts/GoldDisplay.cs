using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField]
    TMP_Text goldDisplay;

    Bank bank;

    void Awake()
    {
        goldDisplay = GetComponent<TMP_Text>();
        bank = FindObjectOfType<Bank>();
    }

    void Update()
    {
        ShowGold(bank.CurrentBalance);
    }

    void ShowGold(int amount)
    {
        goldDisplay.text = $"Gold: {amount}";
    }
}
