using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    public float respawnTimeStart;
    [SerializeField] public int remainingRespawns;
    [SerializeField] public int maxRespawns;
    [SerializeField] private GameObject levelFailedMenu;
    [SerializeField] private TextMeshProUGUI respawnsLeftText;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private string[] loseTexts;
    [SerializeField] private float transitionTime;
    [SerializeField] public GameObject defaultSelectedButton;
    [SerializeField] public GameObject levelFailedDefaultButton;
    public bool respawn;

    public Transform respawnPoint;
    public Animator transition;
    public GameObject player, respawnPointArrow;
    public float respawnTime;
    public CameraFollowPlayerX cameraX;
    public CameraFollowPlayerY cameraY;

    public void Respawn()
    {
        if (remainingRespawns > 0)
        {
            Debug.Log("Se respawneaza!");
            Instantiate(respawnPointArrow, respawnPoint.position, Quaternion.identity);
            respawnTimeStart = Time.time;
            respawn = true;
            remainingRespawns -= 1;
        }
        else
        {
            levelFailedMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(levelFailedDefaultButton);
            ChangeLoseText();
        }
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (defaultSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(defaultSelectedButton);
        }
    }

    private void ChangeLoseText()
    {
        int r = Random.Range(0, loseTexts.Length - 1);
        loseText.text = loseTexts[r];
    }

    public void TurnOffOnGameObject(GameObject obj,bool value)
    {
        obj.SetActive(value);
    }

    public void TurnOffGameObject(GameObject obj)
    {
        TurnOffOnGameObject(obj, false);
    }

    public void TurnOnGameObject(GameObject obj)
    {
        TurnOffOnGameObject(obj, true);
    }

    public IEnumerator LoadLevel(Animator transition)
    {
        transition.Play("LevelTransitionBeginning");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextScene()
    {
        //if (SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCount)
           //StartCoroutine(LoadLevel(transition));
    }

    public void ActivarePlayer()
    {
        player.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Time.time > respawnTimeStart + respawnTime && respawn == true && player != null)
        {
            Debug.Log("Respawned");
            ActivarePlayer();
            player.GetComponent<Player>().ResetPlayer();
            player.transform.position = respawnPoint.position;
            respawn = false;
        }
    }
}
