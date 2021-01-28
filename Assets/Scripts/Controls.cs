using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls 
{
    protected Vector2 pullDirection;
    public virtual void initializeControls(){
        return;
    }
    public virtual Vector2 getPullDirection(){
        return Vector2.zero;
    }
    public virtual bool orbify(){
        return false;
    }
    public virtual bool liquefy(){
        return false;
    }

}
