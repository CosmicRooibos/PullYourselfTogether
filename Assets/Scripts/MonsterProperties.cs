using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperties : MonoBehaviour
{
    public bool jumpActive;
    public bool swimActive;
    public bool sinkActive;
    public bool climbActive;
    public bool squeezeActive;

    void Start()
    {
        jumpActive = false;
        swimActive = false;
        sinkActive = false;
        climbActive = false;
        squeezeActive = false;
    }

    //Any user feedback will go into these functions
    public void JumpAcquired()
    {
        jumpActive = true;
        Debug.Log("Jump Power get!!!");
    }

    public void SwimAcquired()
    {
        swimActive = true;
        Debug.Log("Swim Power get!!!");
    }

    public void ClimbAcquired()
    {
        climbActive = true;
        Debug.Log("Climb Power get!!!");
    }

    public void SqueezeAcquired()
    {
        squeezeActive = true;
        Debug.Log("Squeeze Power get!!!");
    }

    public void SinkAcquired()
    {
        sinkActive = true;
        Debug.Log("Sink Power get!!!");
    }

    //Adding generic method:
    public void Upgrade(eUpgradeType type, float val)
    {
        switch (type)
        {
            case eUpgradeType.jump:
                jumpActive = true;
                Debug.Log("Jump Power get!!!");
                break;
            case eUpgradeType.sink:
                jumpActive = true;
                Debug.Log("Jump Power get!!!");
                break;
            case eUpgradeType.swim:
                jumpActive = true;
                Debug.Log("Jump Power get!!!");
                break;
            case eUpgradeType.squeeze:
                jumpActive = true;
                Debug.Log("Jump Power get!!!");
                break;
            case eUpgradeType.climb:
                jumpActive = true;
                Debug.Log("Jump Power get!!!");
                break;
            case eUpgradeType.health:
                this.gameObject.GetComponent<MonsterHealth>().maxHealth += val;
                Debug.Log("Max health increased by " + val);
                break;
            case eUpgradeType.speed:
                //Integrate with the speed variable
                break;
            default:
                break;
        }
    }
}
