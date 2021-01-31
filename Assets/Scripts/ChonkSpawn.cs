using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChonkSpawn : MonoBehaviour
{
    void Awake()
    {
        GameController.instance.spawnPoint = gameObject.transform;
        GameController.instance.monsterCore.transform.parent.position = this.transform.position;
    }
}
