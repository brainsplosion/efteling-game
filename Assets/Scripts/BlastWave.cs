using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    public static BlastWave Instance;
    public Transform range;
    public Collider hit;
    public int dmg;
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
        
    }
    private void LateUpdate()
    {
        if (hit.enabled == true)
            hit.enabled = !hit.enabled;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var attributesManager = other.GetComponent<AttributesManager>();
            attributesManager.TakeDamage(dmg);
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



}
