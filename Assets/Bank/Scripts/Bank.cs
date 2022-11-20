using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
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
            // Lose the game.
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = $"Gold: {CurrentBalance}";
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
