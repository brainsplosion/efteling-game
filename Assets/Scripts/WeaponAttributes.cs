using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    //public AttributesManager attributesManager;
    [SerializeField] private int weaponDamage = 10;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<Obstacle>().HandleDamage(1);
            
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(weaponDamage);
            other.GetComponent<EnemyBase>().Knockback(10);
            
            
        }

    }


}
