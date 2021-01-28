using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Attach to an empty in the scene, please.
Applies game settings on scene load.  


*/


public enum controlSchemeType{
    mouseOnly,
    keyboardOnly,
    xinputPad,
    keyboardAndMouse
}

public class GameSettings : MonoBehaviour
{
    public controlSchemeType currentScheme = 0;
    public int maxFramerate = 60;

    //Apply Game settings
    void Start()
    {
        Application.targetFrameRate = maxFramerate;
        
    }

    void Update(){


    }
}
