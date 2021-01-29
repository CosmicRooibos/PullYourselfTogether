using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour
{
    //variable for floating animation
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    //position storage for floating animation
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        //store starting position
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //float up and down
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MonsterProperties>() != null)
        {
            collision.gameObject.GetComponent<MonsterProperties>().JumpAcquired();
            Destroy(this.gameObject);
        }
    }
}
