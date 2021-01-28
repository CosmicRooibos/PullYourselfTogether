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
    Camera mainCam;
    Vector2 diffVector = Vector2.zero;
    float partialDistance;
    void Start()
    {
        mainCam = Camera.main;
        partialDistance = 0;
    }

    void Update()
    {
        diffVector = chonk.transform.position - Camera.main.transform.position;
        if(diffVector.magnitude > 4){
            MoveCamera();
        }
    }

    void MoveCamera(){
        //if chonk is too far from camera center start moving in that direction to try to keep chonk centered
        
        Camera.main.transform.Translate(Vector3.Lerp(Camera.main.transform.position, diffVector, partialDistance));
    }

}
