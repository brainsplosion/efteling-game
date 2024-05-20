using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{   //WHY WONT YOU WORK!!!!!!!!!!!
    public int maxHealth;
    private int currentHealth;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);

        GetComponent<Collider>().enabled = false; // Disable the collider to stop further collisions
        this.enabled = false; // Disable this script to stop it from running further

        Destroy(gameObject, 5f);
    }
}
