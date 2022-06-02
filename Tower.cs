using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public enum TargetPriority
    {
        First,
        Close,
        Strong
    }

    [Header("Info")]
    public float range;
    private List<Enemy> curEnemiesInRange = new List<Enemy>();
    private Enemy curEnemy;
    public TargetPriority targetPriority;
    public bool rotateTowardsTarget;

    [Header("Attacking")]
    public float attackRate;
    private float lastAttackTime;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    public int projectileDamage;
    public float projectileSpeed;

    void Update()
    {
        if (Time.time - lastAttackTime > attackRate)
        {
            lastAttackTime = Time.time;

            curEnemy = GetEnemy();

            if (curEnemy != null)
            
                Attack();
            
        }
    }

    Enemy GetEnemy()
    {
        curEnemiesInRange.RemoveAll(x => x == null);

        if (curEnemiesInRange.Count == 0)
            return null;

        if (curEnemiesInRange.Count == 1)
            return curEnemiesInRange[0];

        switch (targetPriority)
        {
            case TargetPriority.First:
                {
                    return curEnemiesInRange[0];
                }

            case TargetPriority.Close:
                {
                    Enemy closest = null;
                    float dist = 99;

                    for (int x = 0; x < curEnemiesInRange.Count; x++)
                    {
                        float d = (transform.position - curEnemiesInRange[x].transform.position).sqrMagnitude;

                        if (d < dist)
                        {
                            closest = curEnemiesInRange[x];
                            dist = d;
                        }
                    }
                    return closest;
                }

            case TargetPriority.Strong:
                {
                    Enemy strongest = null;
                    int strongestHealth = 0;

                    foreach (Enemy enemy in curEnemiesInRange)     
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
}