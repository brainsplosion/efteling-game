using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float bulletSpeed = 10f;
    private float bulletDuration = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        bulletDuration -= Time.deltaTime;
        if (bulletDuration <= 0)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var atm = other.GetComponent<AttributesManager>();
            atm.TakeDamage(10);
            Destroy(gameObject);
        }
    }

}
