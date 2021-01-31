using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    //When character collides with goal, it triggers the next level
    private void OnTriggerEnter2D(Collider2D other)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        int idx = SceneManager.GetActiveScene().buildIndex + 1;
        if(idx >= 4)
        {
            idx = 0;
        }
        StartCoroutine(LoadLevel(idx));

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");

        //wait for animation to stop
        yield return new WaitForSeconds(transitionTime);


        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
