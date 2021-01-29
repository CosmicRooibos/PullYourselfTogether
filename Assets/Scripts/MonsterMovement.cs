﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attach to chonk, please.
Control scheme-agnostic way for the creature to move


*/

public class MonsterMovement : MonoBehaviour
{

    Controls chonkControls = new MouseControls();   //todo: check game settings to set chonkControls to the corresponding instance of the inherited class
    Vector2 pullDirection = Vector2.zero;
    Vector2 chonkPosition = Vector2.zero;
    Rigidbody2D chonkRigidBody;
    public int forceMultiplier = 10000;

    //todo: add an accessible speed multiplier for powerups

    void Start()
    {
        chonkControls.initializeControls();
        chonkRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //move chonk towards pullDirection
        pullDirection = chonkControls.getPullDirection(gameObject.transform.position);
        FaceTowards(); //not sure how necessary this will be
        //Debug.DrawLine(transform.position, pullDirection);
        //todo: make these controls more robust
        if(chonkControls.button0()){
            Orbify();
        }
        else if(chonkControls.button1()){
            Liquefy();
        }
        else {
            Approach();
        }
    }

    Vector2 movementDifference;
    void Approach(){
        //mouse cursor should be a certain distance away before chonk starts to move
        //chonk should keep moving until the pull is acceptably close
        //remove the y component unless underwater
        //movementDifference = pullDirection - chonkPosition;
    
        //movementDifference.y = movementDifference.y * 0; //temporary because i didnt want chonk floating
        
            //Apply forces
            chonkRigidBody.AddForce(forceMultiplier*pullDirection);
        
    }
  
    void FaceTowards(){
        //Add delay between chonk facing the pull direction later
        gameObject.transform.LookAt(pullDirection);
    }


    void StopMomentum(){
        
    }

    //todo: be able to run ability modifiers from these functions
    void Orbify(){
        //pull yourself into a compact orb
        
    }

    void Liquefy(){
        //purposely become squishy whenever
        
    }

}
