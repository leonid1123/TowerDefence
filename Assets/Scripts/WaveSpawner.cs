using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    
    public Transform enemyPref;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public float countdown = 2f;
    private int waveNumber = 0;

    public int GetWave()
    {
        return waveNumber;
    }
    public float GetCountdown ()
    {
        return countdown;
    }
    private void Update()
    {
        if (countdown <=0f )
        {
            StartCoroutine( SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown-=Time.deltaTime;

    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for( int i = 0; i < waveNumber; i++ )
        {
             SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPref,spawnPoint.position,spawnPoint.rotation);
    }
}
