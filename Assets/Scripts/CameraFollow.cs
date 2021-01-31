using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Attach to the main camera please.
Makes the camera follow chonk around as they approach the edge of the screen

*/

public class CameraFollow : MonoBehaviour
{

    public GameObject chonkCore; //put chonk in the space shown in the editor please

    bool isUnderwater = false;
    public int onLandOffset = 5;
    Vector3 onLandOffsetVector;

    void Start()
    {
        onLandOffsetVector = new Vector3(0, onLandOffset, Camera.main.transform.position.z);
        //get chonk's properties so this script knows when they are on land or in the water so the camera offset can be changed accordingly
    }

    void Update()
    {
        if(chonkCore == null)
        {
            chonkCore = MonsterHealth.instance.gameObject;
        }
        MoveCamera();
    }

    Vector3 pullDirection;
    Vector3 destination;
    public float cameraOffset = 1.5f;
    
    void MoveCamera(){
        pullDirection = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - Camera.main.WorldToViewportPoint(chonkCore.transform.position));

        if(isUnderwater){
            destination = chonkCore.transform.position + cameraOffset*pullDirection;
        }
        else{
            destination = chonkCore.transform.position + cameraOffset*pullDirection + onLandOffsetVector;
        }
        destination.z = Camera.main.transform.position.z;
        transform.position = destination;
    }
}
