using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    public GameObject effect;
    public static BlastWave Instance;
    public Transform range;
    public Collider hit;
    public int dmg;
    public float cooldown = 6f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        range = GetComponent<Transform>();
        hit = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit.enabled == true)
            hit.enabled = !hit.enabled;
        cooldown -= Time.deltaTime;
    }
   /* private void LateUpdate()
    {
        if (hit.enabled == true)
            hit.enabled = !hit.enabled;
    }*/

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var attributesManager = other.GetComponent<AttributesManager>();
            attributesManager.TakeDamage(dmg);
            other.GetComponent<EnemyBase>().Knockback(10);

        }
    }

    public void Change()
    {
        dmg += 6;
    }

    public void Return()
    {
        dmg -= 6;
    }

    public void Activate()
    {
        if (cooldown <= 0)
        {
            GameObject temp = Instantiate(effect, transform);
            hit.enabled = true;
            cooldown = 6f;
        }
    }



}
