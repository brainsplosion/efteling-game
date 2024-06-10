using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnLogic : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] public Wave[] waves;
    [SerializeField] private GameObject spawn;
    public List<GameObject> species;
    public int currentWaveDir = 0;
    public List<GameObject> spawners;
    public GameObject model; // new
    private bool readyToStart;
    // Start is called before the first frame update
    public GameObject EndCredits;
    private void Start()
    {
        readyToStart = true;
        for (int i =0; i < waves.Length; i++)
        {
            waves[i].Alive = waves[i].amount;
        }
        
    }

    // Update is called once per frame
    private void Update()
    {
        //don't put code above this if statement, will result in errors.
        if (currentWaveDir >= waves.Length)
        {
             EndCredits.SetActive(true);
                Debug.Log(EndCredits.name + " is now active.");
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

    }

    private IEnumerator spawnWave()
    {
        if (currentWaveDir < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveDir].amount; i++)
            {
                int chooser = Random.Range(1, 100);
                //code below randomly assigns what kind of enemy to spawn based on chances
                if (chooser <= waves[currentWaveDir].chanceShoot + waves[currentWaveDir].chanceFloat)
                {
                    if (chooser <= waves[currentWaveDir].chanceShoot)
                    { model = species[1]; }
                    else
                    { model = species[2]; }
                }
                else
                { model = species[0]; }
                GameObject spawnpoint = spawners[Random.Range(0, spawners.Count)];
                GameObject enemy = Instantiate(model, spawnpoint.transform);
                enemy.transform.SetParent(spawn.transform);
                yield return new WaitForSeconds(waves[currentWaveDir].timeToNextEnemy);
            }
        }
        
    }


}

[System.Serializable]
public class Wave
{
    public float timeToNextEnemy;
    public float timeToNextWave;
    public int amount; //number of enemies in wave
    public int chanceShoot; //percentage of enemies spawned being shooter, 10 will be 10% for example, disclaimer: chanceShoot + Float should never be more than 99
    public int chanceFloat;

    [HideInInspector] public int Alive;
}
