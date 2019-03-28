using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100; //vida inimigo

    public GameObject deathEffect;

    public void TakeDamage (int damage) //função dano no inimigo
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die() //morrer
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
