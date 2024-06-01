using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Teleporter : MonoBehaviour
{
    public Animator sceneTranzitorAnimator;

    public void Awake()
    {
        sceneTranzitorAnimator = GameObject.Find("SceneTranzitor").transform.GetChild(0).GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackDetails attackDetails = new AttackDetails(Vector2.zero,100,0,0,"up");
        if(GameObject.Find("Player") != null)
             GameObject.Find("Player").SetActive(false);
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        sceneTranzitorAnimator.Play("SceneEnd");
        yield return new WaitForSeconds(sceneTranzitorAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
