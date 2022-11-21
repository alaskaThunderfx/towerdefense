using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Bank : MonoBehaviour
{
    [SerializeField]
    GameObject winTextObject;
    [SerializeField]
    GameObject playAgainButton;

    [SerializeField]
    int startingBalance = 150;

    [SerializeField]
    int currentBalance;
    public int CurrentBalance
    {
        set
        {
            currentBalance = value;
            UpdateDisplay();
            WinSequence();
        }
        get { return currentBalance; }
    }

    [SerializeField]
    TextMeshProUGUI displayBalance;

    void Awake()
    {
        CurrentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        CurrentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        CurrentBalance -= Mathf.Abs(amount);

        if (CurrentBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = $"Gold: {CurrentBalance}";
    }

    public void ReloadScene()
    {
        SetWinObjects(false);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void WinSequence()
    {
        if (currentBalance >= 500)
        {
            SetWinObjects(true);
        }
    }

    private void SetWinObjects(bool tOrF)
    {
        winTextObject.SetActive(tOrF);
        playAgainButton.SetActive(tOrF);
    }
}
