using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    public Image healthBar;
    public float maxHealth = 200f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealth(float amount)
    {
        healthBar.fillAmount = amount / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }*/
        //if (healthAmount > 30)
        //{

        //    if (Input.GetKeyDown(KeyCode.Keypad9))
        //    {
        //        TakeDamage2(20);
        //    }
        //}
        //if (healthAmount <= 180)
        //{
        //    if (Input.GetKeyDown(KeyCode.Keypad0))
        //    {
        //        Heal(10);
        //    }
        //}
    }

    //public void TakeDamage2(float damage)
    //{
    //    healthAmount -= damage;
    //    healthBar.fillAmount = healthAmount / 200f;
    //}

    //public void Heal(float healingAmount)
    //{
    //    healthAmount += healingAmount;
    //    healthAmount = Mathf.Clamp(healthAmount, 0, 100);

    //    healthBar.fillAmount = healthAmount / 100f;
    //}
}
