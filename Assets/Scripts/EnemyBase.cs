using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    Rigidbody body;
    [SerializeField] public float MoveSpeed = 4f;
    [SerializeField] public int MinDist = 7;
    private Vector3 KDirect;
    private Transform Player;
    private NavMeshAgent nav;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        GameObject tempTarget = GameObject.FindGameObjectWithTag("Player");
        Player = tempTarget.transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = MoveSpeed;
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
        nav.destination = Player.position;
        if (Vector3.Distance(transform.position, Player.position) <= 1)
        {
            Knockback(3);
        }


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