using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyShoot : EnemyBase
{
    [SerializeField] private float bulletTimer = 4f;
    private float timer;
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        GameObject tempTarget = GameObject.FindGameObjectWithTag("Player");
        Player = tempTarget.transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = MoveSpeed;
        timer = bulletTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            nav.speed = 0;
            if (timer >= bulletTimer)
            {
                transform.LookAt(Player);
                GameObject temp = Instantiate(bullet, transform.position, transform.rotation);
                temp.transform.SetParent(this.transform);
                timer = 0;
            }
            /*transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= 1)
            {
                Knockback(3);
            }*/
        }
        else if (Vector3.Distance(transform.position, Player.position) > MinDist && nav.speed == 0)
        {
            nav.speed = MoveSpeed;
        }
        /*transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
        /*transform.position += transform.forward * MoveSpeed * Time.deltaTime;*/
        nav.destination = Player.position;
        /*if (Vector3.Distance(transform.position, Player.position) <= 1)
        {
            Knockback(3);
        }*/


    }

    public void Knockback(int strength)
    {
        KDirect = new Vector3(transform.position.x - Player.position.x, 0, transform.position.z - Player.position.z);
        KDirect = KDirect.normalized * strength;
        body.AddForce(KDirect, ForceMode.Impulse);
        //body.AddForce(Player.position - transform.position, ForceMode.Force);
        //transform.position -= transform.forward * Distance;
    }
}