using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps: MonoBehaviour{

private GameManager gameManager;
private Enemy enemy;

public float prcnt = Random.Range(0, 100);

public void Heal(){  
        if (prcnt <= 5){
            gameManager.health += 10;
        };
    }


public void Slow(){
        if (prcnt <= 5){
           enemy.moveSpeed -= 1;
        };
    }
}