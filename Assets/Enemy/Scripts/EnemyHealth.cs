using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHP = 2;

    [Tooltip("Adds amount to max HP when enemy dies.")]
    [SerializeField]
    int difficultyRamp = 1;

    int currentHP = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHP = maxHP;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;
        if (currentHP <= 0)
        {
            maxHP += difficultyRamp;
            enemy.RewardGold();
            gameObject.SetActive(false);
        }
    }
}
