using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(MonsterHealth.instance.healthBarFG == null)
        {
            MonsterHealth.instance.healthBarFG = this.gameObject.GetComponent<Image>();
        }
    }
}
