using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect1 : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
}
