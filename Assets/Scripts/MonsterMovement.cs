using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attach to chonk, please.
Control scheme-agnostic way for the creature to move


*/

public class MonsterMovement : MonoBehaviour
{

    Controls chonkControls = new MouseControls();
    //todo: check game settings to set chonkControls to the corresponding instance of an inherited class

    Vector2 pullDirection = Vector2.zero;
    Vector2 chonkPosition = Vector2.zero;
    Rigidbody2D chonkRigidBody;

    void Start()
    {
        chonkControls.initializeControls();
        chonkRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //move chonk towards pullDirection
        chonkPosition = gameObject.transform.position;
        pullDirection = chonkControls.getPullDirection();
        FaceTowards();
        Approach();


        //todo: make these controls more robust
        if(chonkControls.orbify()){
            Orbify();
        }
        if(chonkControls.liquefy()){
            Liquefy();
        }
    }

    Vector2 movementDifference;
    void Approach(){
        //mouse cursor should be a certain distance away before chonk starts to move
        //chonk should keep moving until the pull is acceptably close
        //remove the y component unless underwater
        movementDifference = pullDirection - chonkPosition;
        

        movementDifference.y = movementDifference.y * 0;
        
            //Apply forces
            chonkRigidBody.AddForce(50*movementDifference);
        
    }
  
    void FaceTowards(){
        //Add delay between chonk facing the pull direction later
        gameObject.transform.LookAt(pullDirection);
    }


    void StopMomentum(){


    }

    void Orbify(){
        //pull yourself into a compact orb

    }

    void Liquefy(){
        //purposely become squishy whenever

    }

}
