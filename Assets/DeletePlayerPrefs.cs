using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayerPrefs : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("levelAt", 2);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("levelAt", 4);
        }
    }
}
