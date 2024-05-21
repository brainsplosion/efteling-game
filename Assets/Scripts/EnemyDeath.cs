using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{   //WHY WONT YOU WORK!!!!!!!!!!!
    public int maxHealth;
    public int currentHealth;
    public AttributesManager stats;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        stats = GetComponent<AttributesManager>(); //need to add to stop null 
    }

    public void Update()
    {
        if(stats.health <= 0)
        {
            Debug.Log("it work");
            Die();
        }
      
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

    public void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);

        GetComponent<Collider>().enabled = false; // Disable the collider to stop further collisions
        this.enabled = false; // Disable this script to stop it from running further

        Destroy(gameObject, 5f);
    }

    
}
