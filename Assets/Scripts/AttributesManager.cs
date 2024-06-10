using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributesManager : MonoBehaviour
{
    public float health = 200;
    public int attackDamage;
    //public GameObject healthManager = GameObject.Find("HealthManager");
    public AudioSource hitting; 


    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health < 0)
            health = 0;

        if (transform.CompareTag("Player"))
        {
            HealthManager.Instance.UpdateHealth(health);
        }
       
        //var atm = healthManager.GetComponent<HealthManager>();

        Vector3 randomness = new Vector3(Random.Range(0f, 0.25f), Random.Range(0f, 0.25f), Random.Range(0f, 0.25f));
        DamagePopUpGenerator.current.CreatePopUp(transform.position + randomness, amount.ToString(), Color.green);
    }

    public void DealDamage(GameObject target, PlayerController player)
    {
        var attributesManager = target.GetComponent<AttributesManager>();
        if (attributesManager != null)
        {
            /*if (target.CompareTag("Player"))
            {
                healthManager.TakeDamage2(attack);
            }
            else
            {
                atm.TakeDamage(attack);
            }*/
            attributesManager.TakeDamage(attackDamage);
        }
    }

}
