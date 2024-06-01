using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToGameManager : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }
    public void RespawnPlayer()
    {
        gameManager.Respawn();
    }
}
