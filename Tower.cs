using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour 
{
     public enum TargetPriority
    {
        First,
        Close,
        Strong
    }

     [Header("Info")]
    public float range;
    protected List<Enemy> currentEnemiesInRange = new List<Enemy>();
    protected Enemy currentEnemy;
    public TargetPriority targetPriority;
    public bool rotateTowardsTarget;

    [Header("Attacking")]
    public float attackRate;
    protected float lastAttackTime;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    public int projectileDamage;
    public float projectileSpeed;

    protected abstract void Update();
    protected abstract Enemy GetEnemy();
    protected abstract void Attack();
    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
} 