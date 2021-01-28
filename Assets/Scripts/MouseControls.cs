using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
The mouse cursor needs to be captive to the game window



*/

public class MouseControls : Controls
{

    public override void initializeControls()
    {
        //locks the mouse cursor to the game screen
        Cursor.lockState = CursorLockMode.Confined;
    }

    public override Vector2 getPullDirection(){
        //get mouse cursor position in game space and convert it to something usable
        pullDirection.x = Input.mousePosition.x;
        pullDirection.y = Input.mousePosition.y;
        return Camera.main.ScreenToWorldPoint(pullDirection);
    }

    public override bool orbify()
    {
        //returns Left click
        return Input.GetMouseButton(0);
    }

    public override bool liquefy()
    {
        //returns Right click
        return Input.GetMouseButton(1);
    }

}
