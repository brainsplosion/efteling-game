using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public int health = 100;
    public int attack;
    private Animator _animator;
    public bool isDead
    {
        get
        {
            return health == 0; 
        }
    }


    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health < 0) 
            health = 0;

        Vector3 randomness = new Vector3(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f), Random.Range(0f, 0.25f));
        DamagePopUpGenerator.current.CreatePopUp(transform.position + randomness, amount.ToString(), Color.green);
    }

    public void DealDamage(GameObject target, PlayerController player)
    {
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);

            if (atm.isDead)
            {
                // Trigger death animation
                atm.Death();
            }
        }
    }

    private void Death()
    {
        if (isDead)
        {
            _animator.SetTrigger("Death");
        }
    }

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
