using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance =  Mathf.Infinity;

        for(int i = 0; i < enemies.Length; ++i)
        {
            float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemies[i].transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);
    
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        // or you can use var lol
        ParticleSystem.EmissionModule emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
