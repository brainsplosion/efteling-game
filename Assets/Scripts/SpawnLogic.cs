using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLogic : MonoBehaviour
{

    public List<GameObject> spawners;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void Spawn(int species)
    {
        int randomSpot = Random.Range(0, spawners.Count + 1);
        Vector3 location = new Vector3(spawners[randomSpot].transform.position.x, spawners[randomSpot].transform.position.y, spawners[randomSpot].transform.position.z);
        GameObject currentEnemy = Instantiate(enemies[species], location, Quaternion.identity);
    }
}
