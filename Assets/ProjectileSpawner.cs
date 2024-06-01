using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float rate;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float beginningDelay;
    public float waveCountdown;
    int currentWave = 0;

    public enum SpawnState { SPAWNING, COUNTING, FINISHED };

    private SpawnState state = SpawnState.COUNTING;

    [System.Serializable]
    public class Wave
    {
        public Transform[] locations;
    }

    public Wave[] waves;

    private void Awake()
    {
        waveCountdown = beginningDelay;
    }

    private void Update()
    {
        if (state == SpawnState.COUNTING)
        {
            if (waveCountdown <= 0f)
            {
                SpawnWave(currentWave);
            }
            else
            {
                Debug.Log("aici");
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnWave(int index)
    {
        state = SpawnState.SPAWNING;
        Debug.Log("Spawning ballz");
        for (int i = 0; i < waves[index].locations.Length; i++)
        {
            Instantiate(projectile, waves[index].locations[i].position, Quaternion.identity);
            yield return new WaitForSeconds(1f / rate);
        }

        state = SpawnState.COUNTING;
        currentWave = index + 1 % waves.Length;
        waveCountdown = rate;
        yield break;
    }
}
