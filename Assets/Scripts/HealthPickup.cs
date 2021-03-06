﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float heal;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterBodyPart>() != null)
        {
            MonsterHealth.instance.Heal(heal);
            Destroy(this.gameObject);
        }
    }
}
