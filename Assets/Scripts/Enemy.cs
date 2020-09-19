using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed;

    [HideInInspector]
    public float Speed = 5f;

    public float health=100;
    public int value = 50;

    public GameObject deathEffect;

    // Start is called before the first frame update
    private void Start()
    {
        Speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        playerStats.Money += value;
        Destroy(gameObject);
    }

    public void Slow(float slowAmount)
    {
        Speed = startSpeed * (1f - slowAmount);
    }
}
