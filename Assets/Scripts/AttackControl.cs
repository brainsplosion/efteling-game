using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            //float cd = BlastWave.Instance.cooldown;
            anim.SetTrigger("Attack2");
        }
    }
}
