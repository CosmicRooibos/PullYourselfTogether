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

    void Start()
    {
        //get chonk's properties so this script knows when they are on land or in the water so the camera offset can be changed accordingly
    }

    void Update()
    {
        //i also want to separate the camera x and y movements
            MoveCamera();
    }


    Vector3 pullDirection;
    Vector3 destination;
    float pullSpeed = 7f;
    
    void MoveCamera(){
        pullDirection = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - Camera.main.WorldToViewportPoint(chonk.transform.position));
        destination = chonk.transform.position + pullSpeed*pullDirection;
        destination.z = Camera.main.transform.position.z;
        transform.position = destination;
    }

}
