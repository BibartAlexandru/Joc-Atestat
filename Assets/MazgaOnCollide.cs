using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazgaOnCollide : MonoBehaviour
{
    public GameObject mazgaSplash;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != 25)
            Instantiate(mazgaSplash, collision.transform.position, Quaternion.identity);
    }
}
