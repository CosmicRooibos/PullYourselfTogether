using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;
    public MonsterHealth playerHealth;
    public bool isDamaging;
    public float timer = 0f;

    public List<GameObject> bodyPartsColliding;

    /*
    void Awake()
    {
        playerHealth = GameController.MyInstance.monsterCore.GetComponent<MonsterHealth>();
    }
    */
    void Update()
    {
        if (playerHealth == null)
        {
            playerHealth = GameController.MyInstance.monsterCore.GetComponent<MonsterHealth>();
        }
        /*if (isDamaging)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer -= 1f;
                playerHealth.Hurt(damage);
            }
        }*/
        if(bodyPartsColliding.Count > 0)
        {
            if (!isDamaging)
            {
                isDamaging = true;
                timer = 1f;
            }
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer -= 1f;
                playerHealth.Hurt(damage);
            }
        }
        if(bodyPartsColliding.Count==0)
        {
            isDamaging = false;
            timer = 0f;
        }
    }

    //This set of methods is for colliders- things you collide with and can't pass through.

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterBodyPart>() != null && !isDamaging)
        {
            bodyPartsColliding.Add(collision.gameObject);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MonsterBodyPart>() != null)
        {
            bodyPartsColliding.Remove(collision.gameObject);
        }
    }

    //This set is for triggers- areas you can pass through, that won't stop you, and just hurt.

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterBodyPart>() != null && !isDamaging)
        {
            bodyPartsColliding.Add(collision.gameObject);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterBodyPart>() != null)
        {
            bodyPartsColliding.Remove(collision.gameObject);
        }
    }
}
