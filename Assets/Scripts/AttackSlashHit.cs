﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlashHit : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 0.16f);
    }
}
