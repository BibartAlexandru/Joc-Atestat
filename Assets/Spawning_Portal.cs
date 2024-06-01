using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Portal : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private float delay;
    [SerializeField] private GameObject spawnAble;
    private bool once = false;

    private void Awake()
    {
        GameObject.Instantiate(particle, transform.position, Quaternion.identity);
    }
    private void Update()
    {
        if (delay <= 0 && once == false)
        {
            GameObject.Instantiate(spawnAble, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else
            delay -= Time.deltaTime;
    }

}
