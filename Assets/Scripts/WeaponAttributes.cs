using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttributes : MonoBehaviour
{
    public AttributesManager atm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            other.GetComponent<Obstacle>().HandleDamage(1);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.GetComponent<AttributesManager>().TakeDamage(atm.attack);
        }
        
    }


}
