using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    //where we want our enemies to spawn
    public Transform spawnPoint;

    public float timeBetweenSpawns;
    private float _spawnCounter;

    public int amountToSpawn = 15;

    public Castle theCastle;
    public Path thePath;

    // Start is called before the first frame update
    void Start()
    {
        _spawnCounter = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (amountToSpawn > 0)
        {
            _spawnCounter -= Time.deltaTime;
            if (_spawnCounter <= 0)
            {
                _spawnCounter = timeBetweenSpawns;

                //Instantiate is how we create a new object.  and we have to give what we are spawning, where we are spawning, rotation of the spawn.
                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(theCastle, thePath);

                amountToSpawn--;
            }
        }
    }
}
