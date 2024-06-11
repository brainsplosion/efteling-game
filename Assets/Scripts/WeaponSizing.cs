using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSizing : MonoBehaviour
{
    public static WeaponSizing Instance;
    public GameObject sword;
    public GameObject area;
    private Transform length;

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
        length = area.GetComponent<Transform>();

    }
    public void Biggerer()
    {
        sword.gameObject.transform.localScale += new Vector3(0, (float)0.02, 0);
        length.localScale += new Vector3((float)0.4, 0, 0);
    }

    public void Smallerer()
    {
        sword.gameObject.transform.localScale -= new Vector3(0, (float)0.02, 0);
        length.localScale -= new Vector3((float)0.4, 0, 0);

    }

}
