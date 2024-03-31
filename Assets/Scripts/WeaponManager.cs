using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;

    public void EnableWeaponCollider(int isEnable)
    {
        //Check if the character is holding a weapon
        if(weapon != null)
        {
            var col = weapon.GetComponent<Collider>();

            //Check if the weapon has a collider
            if(col != null)
            {
                if (isEnable == 1)
                {
                    col.enabled = true;
                }
                else
                {
                    col.enabled = false;
                }
            }
        }
    }
}
