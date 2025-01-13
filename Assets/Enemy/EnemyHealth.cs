using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [Tooltip("Adds amount to maxHp when enemy dies")]
    [SerializeField] int diffucultyLevel = 1;
    [SerializeField] int maxHp = 5;
    [SerializeField] int damage = 1;
    int currentHp;
    Enemy enemy;
    void OnEnable()
    {
        currentHp = maxHp;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log(currentHp);
        currentHp -= damage;
        if (currentHp < 0)
        {
            gameObject.SetActive(false);
            maxHp += diffucultyLevel;
            enemy.GoldReward();
        }
    } 
}
