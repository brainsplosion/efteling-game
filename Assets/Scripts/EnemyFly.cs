using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyFly : EnemyBase
{
    private bool recovered = true;
    private float timer = 2f;
    private Transform flyTarget;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        GameObject tempTarget = GameObject.FindGameObjectWithTag("Player");
        Player = tempTarget.transform;
        GameObject tempFly = GameObject.Find("FlyTarget");
        flyTarget = tempFly.transform;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= 1)
            {
                Knockback(3);
            }
        }*/
        /*transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
        /*transform.position += transform.forward * MoveSpeed * Time.deltaTime;*/
        if (recovered)
        {
            if (Vector3.Distance(transform.position, Player.position) <= MinDist)
            {
                transform.LookAt(Player);
            }
            else
            {
                transform.LookAt(flyTarget);
            }
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }
        else if (!recovered)
        {
            timer -= Time.deltaTime;
            transform.position += transform.forward * -2 * Time.deltaTime;
            if (timer <= 0)
            {
                recovered = true;
                timer = 2f;
            }
        }
        if (Vector3.Distance(transform.position, Player.position) <= 1)
        {
            body.useGravity = true;
            Knockback(3);
        }


    }

    override public void Knockback(int strength)
    {
        bopped();
        /*KDirect = new Vector3(transform.position.x - Player.position.x, 0, transform.position.z - Player.position.z);
        KDirect = KDirect.normalized * strength;
        body.AddForce(KDirect, ForceMode.Impulse);*/
        //body.AddForce(Player.position - transform.position, ForceMode.Force);
        //transform.position -= transform.forward * Distance;
    }


    private void bopped()
    {
        recovered = false;
        body.useGravity = true;
        new WaitForSeconds(2);
        body.useGravity = false;
    }

}