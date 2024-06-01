using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSlashScript : MonoBehaviour
{
    Transform CorpDeUrmarit;
    public float timeUntilDestruction;
    private void Awake()
    {
        Destroy(gameObject,timeUntilDestruction);
    }
    public void Update()
    {
        if(CorpDeUrmarit != null)
            transform.position = CorpDeUrmarit.position;
    }

    public void trackPosition(Transform pozitie)
    {
        CorpDeUrmarit = pozitie;
    }
}
