using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnLogic : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] public Wave[] waves;
    [SerializeField] private GameObject spawn;
    public int currentWaveDir = 0;
    public List<GameObject> spawners;
    private bool readyToStart;
    /*public List<GameObject> enemies = new List<GameObject>();
    private List<GameObject> surviving;*/

    /*private bool activeWave()
    {
        surviving = surviving.Where(e => e != null).ToList();
        return surviving.Count > 0;
    }*/
    // Start is called before the first frame update
    private void Start()
    {
        readyToStart = true;
        for (int i =0; i < waves.Length; i++)
        {
            waves[i].Alive = waves[i].enemies.Length;
        }
        //Spawn(0);
    }

    // Update is called once per frame
    private void Update()
    {
        //don't put code above this if statement, will result in errors.
        if (currentWaveDir >= waves.Length)
        {
            Debug.Log("You live!!");
            return;
        }

        if (readyToStart == true)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyToStart = false;
            countdown = waves[currentWaveDir].timeToNextWave;
            StartCoroutine(spawnWave());
        }

        if (waves[currentWaveDir].Alive == 0)
        {
            readyToStart = true;
            currentWaveDir++;
        }
        /*
        if (Input.GetKeyDown(KeyCode.I))
        {
            Spawn(0);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(surviving.Count);
        }*/
    }

    private IEnumerator spawnWave()
    {
        if (currentWaveDir < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveDir].enemies.Length; i++)
            {
                GameObject spawnpoint = spawners[Random.Range(0, spawners.Count)];
                EnemyDeath enemy = Instantiate(waves[currentWaveDir].enemies[i], spawnpoint.transform);
                enemy.transform.SetParent(spawn.transform);
                yield return new WaitForSeconds(waves[currentWaveDir].timeToNextEnemy);
            }
        }
        
    }

    /*private void Spawn(int species)
    {
        int randomSpot = Random.Range(0, spawners.Count);
        Vector3 location = new Vector3(spawners[randomSpot].transform.position.x, spawners[randomSpot].transform.position.y, spawners[randomSpot].transform.position.z);
        GameObject currentEnemy = (GameObject) Instantiate(enemies[species], location, Quaternion.identity);
        currentEnemy.transform.parent = GameObject.Find("Spawn logic").transform;
        surviving.Add(currentEnemy as GameObject);
    }*/

}

[System.Serializable]
public class Wave
{
    public EnemyDeath[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int Alive;
}
