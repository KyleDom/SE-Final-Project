using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps: MonoBehaviour{

void PowerUp(){
            playerhp = GameManager.health
            enemyspeed = Enemy.moveSpeed

            float prcnt = Random.Range(0, 100);
        
            void Slow(){
                enemySpeed -= 2;
                }

            void Heal(){
                playerhp += 100;
            }
        
            if (prcnt <= 5){
            Slow() || Heal();
            };
        }

}