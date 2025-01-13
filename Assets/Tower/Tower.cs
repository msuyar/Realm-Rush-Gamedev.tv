using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost;
    [SerializeField] [Range(0, 2)] float buildTime = 0.5f;

    void Start()
    {
        StartCoroutine(Build());
    }
    public bool CreateTower(Tower towerPrefab, Vector3 towerPos)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }
        if(bank.CurrentBalance >= towerCost)
        {
            Instantiate(towerPrefab, towerPos, Quaternion.identity);
            bank.Withdraw(towerCost);
            return true;
        }
        
        return false;
    }

    IEnumerator Build()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }

        }

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildTime);
            
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }

        }
    }
}
