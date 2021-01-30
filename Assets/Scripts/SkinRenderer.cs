using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinRenderer : MonoBehaviour
{
    public Transform twin;
    // Use this for initialization
    void Start()
    {
        //transform.GetComponent<LineRenderer>().positionCount = parentSkin.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        transform.GetComponent<LineRenderer>().SetPosition(1, twin.position);

        /*
        for (int i = 0; i < parentSkin.childCount; i++)
        {
            transform.GetComponent<LineRenderer>().SetPosition(i, parentSkin.GetChild(i).position);
        }
        */
    }
}
