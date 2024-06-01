using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTranzitor : MonoBehaviour
{
    private Animator animator;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        Debug.Log("hi");
        animator.Play("SceneBegin");
    }
}
