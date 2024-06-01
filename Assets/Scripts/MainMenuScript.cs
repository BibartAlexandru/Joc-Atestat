using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayJoc1()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void PlayJoc2()
    {
        SceneManager.LoadScene("TopDownShooter");
    }
}
