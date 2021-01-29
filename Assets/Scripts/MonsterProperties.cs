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
}
