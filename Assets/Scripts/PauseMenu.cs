using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject[] UIsToDisable;
    [SerializeField] public GameObject defaultSelectedButton;
    public static bool isPaused;
    private float oldTimeScale;

    public void Start()
    {
        if(pauseMenu)
            pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void PauseGame()
    {
        foreach (AudioSource a in GameObject.FindObjectsOfType<AudioSource>())
            a.Pause();
        pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
        oldTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        isPaused = true;
        for (int i = 0; i < UIsToDisable.Length; i++)
            if(UIsToDisable[i] != null)
                UIsToDisable[i].gameObject.SetActive(false);
    }

    public void PauseResumeGame()
    {
        if (isPaused == false)
            PauseGame();
        else
            ResumeGame();
    }

    public void ResumeGame()
    {
        foreach (AudioSource a in GameObject.FindObjectsOfType<AudioSource>())
            a.UnPause();
        Time.timeScale = oldTimeScale;
        pauseMenu.SetActive(false);
        isPaused = false;
        for (int i = 0; i < UIsToDisable.Length; i++)
            if(UIsToDisable[i] != null)
                UIsToDisable[i].gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Application Closed!");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Menu");
    }
}
