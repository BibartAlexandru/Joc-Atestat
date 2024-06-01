using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    private Collider2D collider2D;
    bool stop;
    [SerializeField] private Spike_Without_Telehraph[] spikes;


    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        stop = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!stop)
        {
            if (collision.gameObject.CompareTag("Player"))
                for (int i = 0; i < spikes.Length; i++)
                    spikes[i].Rise();
            stop = true;
        }
    }
}
