using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSizing : MonoBehaviour
{
    public static WeaponSizing Instance;
    public GameObject sword;

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
    public void Biggerer()
    {
        sword.gameObject.transform.localScale += new Vector3(0, (float)0.02, 0);
    }

    public void Smallerer()
    {
        sword.gameObject.transform.localScale -= new Vector3(0, (float)0.02, 0);

    }

}
