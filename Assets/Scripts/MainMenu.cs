using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject canvasMain;
    [SerializeField] GameObject canvasLevelSelect;
    [SerializeField] ParticleSystem ps;
    [SerializeField] public GameObject defaultSelectedButton;
    [SerializeField] public GameObject defaultSelectedButtonLevels; 

    public void Awake()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void ShowLevels()
    {
        canvasLevelSelect.SetActive(true);
        canvasMain.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButtonLevels);
    }

    public void BackToMainMenu()
    {
        canvasLevelSelect.SetActive(false);
        canvasMain.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
    }

    public void QuitGame()
    {
        Debug.Log("Application Closed!");
        Application.Quit();
    }


}
