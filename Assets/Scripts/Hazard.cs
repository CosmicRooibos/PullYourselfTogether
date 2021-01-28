using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage;
    public MonsterHealth playerHealth;
    public bool isDamaging;
    public float timer = 0f;

    void Update()
    {
        if (isDamaging)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                timer -= 1f;
                playerHealth.Hurt(damage);
            }
        }
    }

    //This set of methods is for colliders- things you collide with and can't pass through.

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterHealth>() != null)
        {
            playerHealth = collision.gameObject.GetComponent<MonsterHealth>();
            isDamaging = true;
            timer = 1f;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MonsterHealth>() != null)
        {
            playerHealth = null;
            isDamaging = false;
            timer = 1f;
        }
    }

    //This set is for triggers- areas you can pass through, that won't stop you, and just hurt.

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterHealth>() != null)
        {
            playerHealth = collision.gameObject.GetComponent<MonsterHealth>();
            isDamaging = true;
            timer = 1f;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterHealth>() != null)
        {
            playerHealth = null;
            isDamaging = false;
            timer = 1f;
        }
    }
}
