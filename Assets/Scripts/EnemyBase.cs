using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemeyBase : MonoBehaviour
{
    Collision collision;
    [SerializeField] public float MoveSpeed = 4f;
    [SerializeField] public int MinDist = 7;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            transform.LookAt(Player);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, Player.position) <= 1)
                Knockback(1);

        }

    }

    private void Knockback(int Distance)
    {
        transform.position -= transform.forward * Distance;
    }
}
