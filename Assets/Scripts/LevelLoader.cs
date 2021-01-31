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
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

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
