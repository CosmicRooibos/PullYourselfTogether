using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
Attach to chonk, please.
Control scheme-agnostic way for the creature to move


*/

public class MonsterMovement : MonoBehaviour
{
    public MonsterProperties monProp;
    Controls chonkControls = new MouseControls();   //todo: check game settings to set chonkControls to the corresponding instance of the inherited class
    Vector2 pullDirection = Vector2.zero;
    Vector2 chonkPosition = Vector2.zero;
    Rigidbody2D chonkRigidBody;
    public int forceMultiplier = 10000;

    //Jump Variables
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    bool jumpRequest;
    bool grounded = true;

    public LayerMask mask;
    public float groundClearance;

    float playerSize;
    Vector2 groundBoxSize;

    public Transform guts;
    public Rigidbody2D[] gutsChildren;

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float volume = 1f;
    public bool loop = false;

    //todo: add an accessible speed multiplier for powerups

    void Start()
    {
        chonkControls.initializeControls();
        chonkRigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerSize = GetComponent<CircleCollider2D>().radius;
        groundBoxSize = new Vector2(playerSize * 2, groundClearance);
        gutsChildren = guts.GetComponentsInChildren<Rigidbody2D>();
    }

    void Update() //Yes, this code needs to be in Update, *not* FixedUpdate. Don't move it into FixedUpdate, or else it will intermittently fail to activate for what I can only describe as "no good reason." Trust me on this one. -Horizon
    //Also, leaving this code commented out until someone else can review it and make sure it's good.
    {
        if (Input.GetMouseButtonDown(0) && grounded && monProp.jumpActive)
        {
            jumpRequest = true;
            grounded = false;
        }
    }

    void FixedUpdate()
    {
        //move chonk towards pullDirection
        pullDirection = chonkControls.getPullDirection(gameObject.transform.position);
        FaceTowards(); //not sure how necessary this will be
        //Debug.DrawLine(transform.position, pullDirection);
        //todo: make these controls more robust
        /*                                              //Jacob's note: I commented this out because holding the button made it unable to move.
        if(chonkControls.button0()){
            Orbify();
        }
        else if(chonkControls.button1()){
            Liquefy();
        }
        */
        //else {
            Approach();
        //}
        //Loops the Chonk Move SFX
        bool loop = true;
        audioSource.PlayOneShot(audioClipArray[0], 1f);

        if (jumpRequest) //This code is for executing the jump stuff. When you press the jump button, then jumpRequest will be set to true in Update. Then, in this part of the code, jumpRequest will cause the rigidbody to shoot up into the air, and set jumpRequest to false. That, on its own, would be sufficient... but that's not good enough for me. Come down a few lines with me. -Horizon
        {
            chonkRigidBody.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            foreach (Rigidbody2D gut in gutsChildren)
            {
                gut.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            }
            jumpRequest = false;
            //Plays the Chonk Jump SFX
            audioSource.Stop();
            audioSource.PlayOneShot(audioClipArray[1], 1f);
        }
        else //If you're not jumping, then this code checks to see if you're grounded or not.
        {
            Vector2 boxCenter = (Vector2)transform.position + (Vector2.down * ((playerSize * 2)+groundBoxSize.y)*0.5f);
            grounded = (Physics2D.OverlapBox(boxCenter, groundBoxSize, 0f, mask) != null);
        }

        if(chonkRigidBody.velocity.y < 0) //Now THIS is where the magic happens. This is where we get such magnificent luxuries as "variable jump height" we can only get from every Mario game from the NES onwards. If Chonk is falling, they will fall faster than they rose, which feels better to play. If you jump but only tap the jump button, Chonk won't go as high because gravity is stronger. If you jump and hold the button instead, Chonk will go higher because gravity isn't getting stronger. And if you're neither falling nor rising, gravity goes back to normal.
        {
            chonkRigidBody.gravityScale = fallMultiplier;
        }
        else if(chonkRigidBody.velocity.y > 0 && !Input.GetMouseButton(0))
        {
            chonkRigidBody.gravityScale = lowJumpMultiplier;
        }
        else
        {
            chonkRigidBody.gravityScale = 1f;
        }

        //As for checking if Chonk is grounded, that's something of a dealer's choice. I got these mechanics from a tutorial series, so here's the link to the ground detection video: https://www.youtube.com/watch?v=CLxXkSIaOAc
        //EDIT: Turns out I'm the dealer now and I choose box detection.


    }

    Vector2 movementDifference;
    void Approach(){
        //mouse cursor should be a certain distance away before chonk starts to move
        //chonk should keep moving until the pull is acceptably close
        //remove the y component unless underwater
        //movementDifference = pullDirection - chonkPosition;
    
        //movementDifference.y = movementDifference.y * 0; //temporary because i didnt want chonk floating
        
            //Apply forces
            chonkRigidBody.AddForce(forceMultiplier*pullDirection);
        
    }
  
    void FaceTowards(){
        //Add delay between chonk facing the pull direction later
        gameObject.transform.LookAt(pullDirection);
    }


    void StopMomentum(){
        
    }

    //todo: be able to run ability modifiers from these functions
    void Orbify(){
        //pull yourself into a compact orb
        
    }

    void Liquefy(){
        //purposely become squishy whenever
        
    }

}
