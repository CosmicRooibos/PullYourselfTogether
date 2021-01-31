using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
    //private const float splineOffset = 0.5f;
    [SerializeField]
    public SpriteShapeController spriteShape;
    [SerializeField]
    public Transform[] points;

    void Awake()
    {
        int editorSplines = spriteShape.spline.GetPointCount(); //get the number of splines present in the editor view
        int resolutionDivisor = 2; //to lower the spline-resolution of chonk's displayed body.  can be 1 for full resolution. set it higher for even less
        int desiredSplines = (transform.childCount - (transform.childCount % resolutionDivisor))/resolutionDivisor;
        
        points = new Transform[desiredSplines];

        for (int i = 0; i <  desiredSplines - 1; i++)
        {
            points[i] = transform.GetChild(i*resolutionDivisor);
            if(i >= editorSplines){
                spriteShape.spline.InsertPointAt(i, points[i].position);
            }
        }
        UpdateVertices();
    }

    void Update()
    {
        UpdateVertices();
    }

    private void UpdateVertices()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            /*
            Vector2 vertex = points[i].localPosition;
            Vector2 towardsCenter = (Vector2.zero - vertex).normalized;
            float colliderRadius = points[i].gameObject.GetComponent<CircleCollider2D>().radius;
            
            try
            {
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * colliderRadius));
            }
            catch
            {
                Debug.Log("Spline points too close, recalculating");
                spriteShape.spline.SetPosition(i, (vertex - towardsCenter * (colliderRadius + splineOffset)));
            }
            */

            try{
                spriteShape.spline.SetPosition(i, points[i].position);
            }
            catch{

            }
        }
    }
}
