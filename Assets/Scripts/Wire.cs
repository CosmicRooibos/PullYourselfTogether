using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        transform.GetComponent<LineRenderer>().positionCount = transform.childCount;
        int count = 1;
        foreach (Transform child in transform)
        {
            if (count < transform.childCount)
                child.GetComponent<SpriteRenderer>().enabled = false;
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetComponent<LineRenderer>().SetPosition(i, transform.GetChild(i).position);
        }

    }
}
