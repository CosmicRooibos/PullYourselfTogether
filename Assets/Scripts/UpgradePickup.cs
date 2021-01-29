using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eUpgradeType
{
    speed,
    health,
    jump,
    swim,
    squeeze,
    climb,
    sink
}

public class UpgradePickup : MonoBehaviour
{
    public eUpgradeType upgradeType; //Determines what kind of upgrade it is; this script will cover pretty much every upgrade pickup we need.
    public float upgradeValue; //For upgrades that make number go up, like speed and health upgrades. For binary ability unlocks, this isn't necessary, so you don't have to do anything with it.

    public void OnTriggerEnter2D(Collider2D collision) //
    {
        if (collision.gameObject.GetComponent<MonsterBodyPart>() != null)
        {
            GameController.MyInstance.monsterCore.GetComponent<MonsterProperties>().Upgrade(upgradeType, upgradeValue);
            Destroy(this.gameObject);
        }
    }
}
