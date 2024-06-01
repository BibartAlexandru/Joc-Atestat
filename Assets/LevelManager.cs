using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

    private void Awake()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",2);
        if (PlayerPrefs.GetInt("setat", 0) == 0)
        {
            PlayerPrefs.SetInt("levelAt", 2);
            PlayerPrefs.SetInt("setat", 1);
        }
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt && i != SceneManager.sceneCount-1)
                levelButtons[i].interactable = false;
        }
    }

    private void Update()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt",2);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                levelButtons[i].interactable = false;
            else
                levelButtons[i].interactable = true;
        }
    }

    public void LoadAScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    
}
