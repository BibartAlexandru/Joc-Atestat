using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING,WAITING,COUNTING,FINISHED };
    [SerializeField] private string objectsTag;
    [SerializeField] GameObject nextLevelPortal;
    [SerializeField] private Transform nextLevelPortalLocation;

    [System.Serializable] //poti modifica variabilele in inspector
    public class Wave
    {
        public string name;
        public GameObject[] enemies;
        public int[] spawnPointIndexes;
        public float rate;
        public UnityEvent terrainChanges;
    }

    public Wave[] waves;
    private int nextWave = 0;

    [SerializeField] private GameObject waveCompletedPopUp;
    [SerializeField] private GameObject waveCountDownUI;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;
    private float searchCountdown = 1f;
    [SerializeField] private bool endless;

    private SpawnState state = SpawnState.COUNTING;

    public void Start()
    {
        if (spawnPoints.Length == 0)
            Debug.LogError("No spawn points referenced!");
        waveCountdown = timeBetweenWaves;
    }

    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemiesAreAlive())
            {
                //Begin a new round
                WaveCompleted();
                return;
            }
            else
            {
                return;
            }
        }

        if (state != SpawnState.FINISHED)
        {
            if (waveCountdown <= 0)
            {
                if (waveCountDownUI)
                    waveCountDownUI.GetComponent<TextMeshProUGUI>().text = "            0 \nTime until next wave";
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
                if (waveCountDownUI)
                    waveCountDownUI.GetComponent<TextMeshProUGUI>().text = "            " + waveCountdown.ToString("0.00") + "\nTime until next wave";
            }
        }
    }

    public void WaveCompleted()
    {
        //Debug.Log("Wave Completed!");
        if (waveCompletedPopUp)
        {
            waveCompletedPopUp.GetComponent<TextMeshProUGUI>().text = waves[nextWave].name + " completed!";
            waveCompletedPopUp.GetComponent<Animator>().Play("WaveCompletedText");
        }

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        nextWave++;

        if (nextWave != waves.Length && waves[nextWave].terrainChanges != null)
            waves[nextWave].terrainChanges.Invoke();

        if (nextWave > waves.Length - 1 && !endless)
        {
            state = SpawnState.FINISHED;
            if (GameObject.Find("Projectile Spawner") != null)
                GameObject.Find("Projectile Spawner").SetActive(false);
            Debug.Log("ALL WAVES COMPLETE! Looping...");
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene + 1 > PlayerPrefs.GetInt("levelAt"))
                PlayerPrefs.SetInt("levelAt", currentScene + 1);

            Instantiate(nextLevelPortal, nextLevelPortalLocation.position, Quaternion.identity);
        }
        else if(nextWave > waves.Length - 1)
            nextWave = 0;
    }

    bool EnemiesAreAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag(objectsTag) == null)
                return false;
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        //Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for(int i = 0; i < _wave.enemies.Length; i++)
        {
            SpawnEnemy(i);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(int index)
    {
        //Debug.Log("Spawning Enemy: " + _enemy.ToString());
        //Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Transform _sp = spawnPoints[waves[nextWave].spawnPointIndexes[index]];
        Instantiate(waves[nextWave].enemies[index], _sp.position, Quaternion.identity);
    }
}
