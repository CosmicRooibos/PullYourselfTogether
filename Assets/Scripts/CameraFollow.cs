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
    Rigidbody2D chonkRigidBody;
    Vector2 diffVector = Vector2.zero;
    float awayFromCenter = 2.5f;
    //float cameraSpeed = 2f;
    public float smoothTime = 0.3f;
    private Vector2 rVelocity = Vector2.zero;

    void Start()
    {
        chonkRigidBody = chonk.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //todo: make the camera follow chonk better.  currently there's a stutter.  also change it so the camera "frames" the character on screen better after stopping 
        //i also want to separate the camera x and y movements
        diffVector = chonk.transform.position - Camera.main.transform.position;
        
        if(diffVector.x > awayFromCenter || diffVector.x < awayFromCenter*-1){
            MoveCamera();
        }

    }

    void MoveCamera(){
        //if chonk is too far from camera center start moving in that direction to try to keep chonk centered
        
        diffVector.y = 0;
        Camera.main.transform.position = Vector2.SmoothDamp(Camera.main.transform.position, (diffVector + chonkRigidBody.velocity),
                                                 ref rVelocity, smoothTime);
    }

}
