using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    [SerializeField] private float timeWait = 3f;
    [SerializeField] private float speed = 4f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }
}
