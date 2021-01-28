using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attach to the main camera please.
Makes the camera follow chonk around as they approach the edge of the screen

*/

public class CameraFollow : MonoBehaviour
{

    public GameObject chonk; //put chonk in the space shown in the editor please
    Vector2 diffVector = Vector2.zero;
    float awayFromCenter = 2.5f;
    float cameraSpeed = 1f;

    void Start()
    {

    }

    void Update()
    {
        //todo: make the camera follow chonk better.  currently there's a stutter.  also change it so the camera "frames" the character on screen better after stopping 
        //i also want to separate the camera x and y movements
        diffVector = 1.5f*chonk.transform.position - Camera.main.transform.position;
        
        if(diffVector.x > awayFromCenter || diffVector.x < awayFromCenter*-1){
            MoveCamera();
        }

    }

    void MoveCamera(){
        //if chonk is too far from camera center start moving in that direction to try to keep chonk centered
        diffVector.y = 0;
        gameObject.transform.Translate(diffVector*cameraSpeed*Time.deltaTime);
    }

}
