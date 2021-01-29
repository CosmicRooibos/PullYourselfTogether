using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls 
{
    protected Vector2 pullDirection;
    public virtual void initializeControls(){
        return;
    }
    public virtual Vector2 getPullDirection(Vector3 chonkPos){
        return Vector2.zero;
    }
    public virtual bool button0(){
        return false;
    }
    public virtual bool button1(){
        return false;
    }

    public virtual bool button0release(){
        return false;
    }

    public virtual bool button1release(){
        return false;
    }
}
