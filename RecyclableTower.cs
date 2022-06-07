using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableTower : Tower
{
    protected override Enemy GetEnemy()
    {
        currentEnemiesInRange.RemoveAll(x => x == null);

        if (currentEnemiesInRange.Count == 0)
            return null;

        if (currentEnemiesInRange.Count == 1)
            return currentEnemiesInRange[0];

        switch (targetPriority)
        {
            case TargetPriority.First:
                {
                    return currentEnemiesInRange[0];
                }

            case TargetPriority.Close:
                {
                    Enemy closest = null;
                    float defaultDistance = 99;

                    for (int x = 0; x < currentEnemiesInRange.Count; x++)
                    {
                        float distanceOfEnemy = (transform.position - currentEnemiesInRange[x].transform.position).sqrMagnitude;

                        if (distanceOfEnemy < defaultDistance) //checks if closer 
                        {
                            closest = currentEnemiesInRange[x];
                            defaultDistance = distanceOfEnemy;
                        }
                    }
                    return closest;
                }

            case TargetPriority.Strong:
                {
                    Enemy strongest = null;
                    int strongestHealth = 0;

                    foreach (Enemy enemy in currentEnemiesInRange)     
                    {
                        if (enemy.health > strongestHealth)
                        {
                            strongest = enemy;
                            strongestHealth = enemy.health;
                        }
                    }
                    return strongest;
                }
        }
        return null;
    }

    protected override void Update()
    {
        if (Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;

            currentEnemy = GetEnemy();

            if (currentEnemy != null)
            
                Attack();
            
        }
    }

    protected override void Attack()
    {
        if (rotateTowardsTarget){
            transform.LookAt(currentEnemy.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        GameObject bullet = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        if(currentEnemy.CompareTag("Recycled")){
            
             bullet.GetComponent<Projectile>().Initialize(currentEnemy, projectileDamage * 2, projectileSpeed);

        }else {

        bullet.GetComponent<Projectile>().Initialize(currentEnemy, projectileDamage, projectileSpeed);

        }
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Biodegradable") || other.CompareTag("NonBiodegradable") || other.CompareTag("Recycled"))
        {
            currentEnemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
         if (other.CompareTag("Biodegradable") || other.CompareTag("NonBiodegradable") || other.CompareTag("Recycled"))
        {
            currentEnemiesInRange.Remove(other.GetComponent<Enemy>());
        }
    }
}