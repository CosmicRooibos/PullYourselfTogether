using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MonsterHealth : MonoBehaviour
{
    public static MonsterHealth instance;
    public float health = 10;
    public float maxHealth = 10;
    public Image healthBarFG;
    //public Transform player;
    //public Transform respawnPoint;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float volume = 1f;

    void Awake()
    {
        health = maxHealth;
        if (instance != null && instance != this)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBar();
        if (GameController.instance.monsterCore == null)
        {
            GameController.instance.monsterCore = this.gameObject;
        }
    }

    public void Hurt(float hurt)
    {
        health -= hurt;
        Debug.Log("Damaged for "+hurt+"! Health now at "+health);
        //Play the Chonk Hurt SFX
        audioSource.PlayOneShot(audioClipArray[0], 1f);
        if (health <= 0)
        {
            health = 0;
            //Play the Chonk Dead SFX
            audioSource.PlayOneShot(audioClipArray[1], 1f);
            this.Kill();
        }
        SetHealthBar();
    }

    public void Kill()
    {
        Debug.Log("killed");
        /* todo: make this disable movement and show a game over screen, maybe some gross particle effects*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        SetHealthBar();
    }

    public void SetHealthBar()
    {
        healthBarFG.fillAmount = (health/maxHealth);
    }
}
