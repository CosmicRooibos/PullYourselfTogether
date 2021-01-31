using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterHealth : MonoBehaviour
{
    public float health = 10;
    public float maxHealth = 10;
    public Image healthBarFG;
    //public Transform player;
    //public Transform respawnPoint;
    
    void Awake()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealthBar();
    }

    public void Hurt(float hurt)
    {
        health -= hurt;
        Debug.Log("Damaged for "+hurt+"! Health now at "+health);
        if (health <= 0)
        {
            health = 0;
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
