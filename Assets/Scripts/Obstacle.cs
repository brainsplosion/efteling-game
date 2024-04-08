using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacle : MonoBehaviour
{
    private int Health = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
            CommitDie();
    }

    private void CommitDie()
    {
        Destroy(gameObject);

    }
}
