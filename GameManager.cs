using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static int health;
    public int money;
    private bool gameActive;

    [Header("Components")]
    public TextMeshProUGUI healthAndMoneyText;
    public EnemyPath enemyPath;
    public TowerPlacement towerPlacement;
    public WaveSpawner waveSpawner;

    [Header("Events")]
    public UnityEvent onMoneyChanged;

    // Singleton
    public static GameManager instance;

    void OnEnable ()
    {
        Enemy.OnDestroyed += OnEnemyDestroyed;
    }

    void OnDisable ()
    {
        Enemy.OnDestroyed -= OnEnemyDestroyed;
    }

    void Awake ()
    {
        instance = this;
    }

    void Start ()
    {
        gameActive = true;
        UpdateHealthAndMoneyText();
        print(health);
    }

    void UpdateHealthAndMoneyText()
    {
        healthAndMoneyText.text = $"Health: {health}\nCredit: {money}";
    }

    public void AddMoney (int amount)
    {
        money += amount;
        UpdateHealthAndMoneyText();

        onMoneyChanged.Invoke();
    }

    public void TakeMoney (int amount)
    {
        money -= amount;
        UpdateHealthAndMoneyText();

        onMoneyChanged.Invoke();
    }

    public void TakeDamage (int amount)
    {
        health -= amount;
        UpdateHealthAndMoneyText();

        if(health <= 0)
            GameOver();
    }

    void GameOver ()
    {
       
    }

    void WinGame ()
    {
        
    }

    public void OnEnemyDestroyed ()
    {
        
    }
}


   
   

