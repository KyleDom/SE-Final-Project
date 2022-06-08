using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public int health; 
    public int DamageToPlayer;
    public int value;
    public float moveSpeed;

    //path 
    private Transform[] path;
    private int currentWaypoint;

    public GameObject healthBarPrefab; 

    void Start (){
        playerhp = GameManager.health
        path = GameManager.instance.enemyPath.waypoints;
        //creating the health bar
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject healthBar = Instantiate(healthBarPrefab, canvas.transform);
        healthBar.GetComponent<EnemyHealthBar>().Initialize(this);
    }

    void PowerUps(){
            float prcnt = Random.Range(0, 100);
        
            void Slow(){
                moveSpeed -= 1;
                }

            void Heal(){
                playerhp += 10;
            }
        
            if (prcnt <= 5){
            Slow() || Heal();
            };
        }

    void Update (){
        Move();
        PowerUps();
    }
}
