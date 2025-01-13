using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25; 
    [SerializeField] int goldPenalty = 10;
    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void GoldReward()
    {
        if(bank == null)
        {
            Debug.LogWarning("No Bank exists");
            return;
        }
        bank.Deposit(goldReward);
    }

    public void GoldPenalty()
    {
        if(bank == null)
        {
            Debug.LogWarning("No Bank exists");
            return;
        }
        bank.Withdraw(goldPenalty);
    }
}
