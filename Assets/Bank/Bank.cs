using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI goldText;

    public int CurrentBalance
    {
        get 
        { 
            return currentBalance; 
        }
    }

    void Awake()
    {
        currentBalance = startingBalance;
        UpdategoldText();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdategoldText();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdategoldText();
        if(currentBalance < 0)
        {
            //Lose the game
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdategoldText()
    {
        goldText.text = "Gold: " + currentBalance.ToString();
    }
}
