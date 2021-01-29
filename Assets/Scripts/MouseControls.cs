using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Converts mouse position on the game screen to a vector which is used to pull the chonk in a direction.
Also checks for left click and right click.
The maximum amount of force will be applied if the mouse cursor is 60% away from the center of the game screen.
This is so you still have screen space to click and drag a little.  

todo: add mouse button release functions
*/

public class MouseControls : Controls
{
    public override void initializeControls()
    {
        //locks the mouse cursor to the game screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    Vector3 viewportCenter = new Vector3(0.5f, 0.5f, 0f);
    
    float maxPull = 0.3f;
    float pullSpeed = 7f;
    public override Vector2 getPullDirection(Vector3 chonkPos){
        //get mouse cursor position in game space and convert it to something usable
        pullDirection = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - Camera.main.WorldToViewportPoint(chonkPos));
        Debug.DrawLine(chonkPos, chonkPos + pullSpeed*(Vector3)pullDirection);
        if(pullDirection.magnitude >= maxPull){
            pullDirection = pullDirection.normalized*maxPull;
        }
        return pullSpeed*pullDirection;
    }

    public override bool button0()
    {
        //returns true on Left click
        return Input.GetMouseButton(0);
    }

    public override bool button1()
    {
        //returns true on Right click
        return Input.GetMouseButton(1);
    }

    public override bool button0release()
    {
        return Input.GetMouseButtonUp(0);
    }    
    public override bool button1release()
    {
        return Input.GetMouseButtonUp(1);
    }    


}
