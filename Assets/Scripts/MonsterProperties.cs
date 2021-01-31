using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//this is for the working copy
public class MonsterProperties : MonoBehaviour
{
    public bool jumpActive;
    public bool swimActive;
    public bool sinkActive;
    public bool climbActive;
    public bool squeezeActive;

    public List<float> healthPickups;
    public List<float> speedPickups;

    public string consumeKey = "c";
    public string squeezeKey = "mouse 1";

    public MonsterHealth healthManager;

    public Transform guts;
    public Transform[] gutsChildren;
    public Vector3 gutsSizeMax; //The original size of each guts ball. 
    public Vector3 gutsSizeMin; //How much the guts will shrink.

    public AudioMixer musicMixer;
    public string layerFade1 = "LayerFade1";
    public string layerFade2 = "LayerFade2";
    public string layerFade3 = "LayerFade3";
    public string layerFade4 = "LayerFade4";
    public string layerFade5 = "LayerFade5";

    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float volume = 1f;

    void Awake()
    {
        gutsChildren = guts.GetComponentsInChildren<Transform>();
        jumpActive = false;
        swimActive = false;
        sinkActive = false;
        climbActive = false;
        squeezeActive = false;
        jumpActive = GameController.instance.jumpActive;
        climbActive = GameController.instance.climbActive;
    }

    void Update()
    {
        if (Input.GetKeyDown(consumeKey)) //Consume Key is, by default, c. This will fire once, each time you press it.
        {
            if (healthPickups.Count > 0)
            {
                healthManager.maxHealth -= healthPickups[healthPickups.Count - 1];
                healthManager.Heal(healthPickups[healthPickups.Count - 1]);
                healthPickups.RemoveAt(healthPickups.Count - 1);
                //Play the Chonk Collect Health SFX
                audioSource.PlayOneShot(audioClipArray[0], 1f);
            }
        }

        //flatten while button is held down
        if (Input.GetKey(squeezeKey))
        {
            if (squeezeActive)
                Squeeze();
            //Play the Chonk Squish SFX
            audioSource.PlayOneShot(audioClipArray[2], 1f);
        }

        if (Input.GetKeyUp(squeezeKey))
        {
            UnSqueeze();
        }
    }

    //Any user feedback will go into these functions
    public void JumpAcquired()
    {
        jumpActive = true;
        GameController.instance.jumpActive = true;
        Debug.Log("Jump Power get!!!");
        //Fade-in Layer 1
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade1, 2f, 1));
        //Play the Chonk Collect Upgrade SFX
        audioSource.PlayOneShot(audioClipArray[1], 1f);
    }

    public void SwimAcquired()
    {
        swimActive = true;
        Debug.Log("Swim Power get!!!");
        //Fade-in Layer 4
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade4, 2f, 1));
        //Play the Chonk Collect Upgrade SFX
        audioSource.PlayOneShot(audioClipArray[1], 1f);
    }

    public void ClimbAcquired()
    {
        climbActive = true;
        Debug.Log("Climb Power get!!!");
        //Fade-in Layer 5
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade5, 2f, 1));
        //Play the Chonk Collect Upgrade SFX
        audioSource.PlayOneShot(audioClipArray[1], 1f);
    }

    public void SqueezeAcquired()
    {
        squeezeActive = true;
        Debug.Log("Squeeze Power get!!!");
        //Fade-in Layer 2
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade2, 2f, 1));
        //Play the Chonk Collect Upgrade SFX
        audioSource.PlayOneShot(audioClipArray[1], 1f);
    }

    public void SinkAcquired()
    {
        sinkActive = true;
        Debug.Log("Sink Power get!!!");
        //Fade-in Layer 3
        StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade3, 2f, 1));
        //Play the Chonk Collect Upgrade SFX
        audioSource.PlayOneShot(audioClipArray[1], 1f);
    }

    //Adding generic method:
    public void Upgrade(eUpgradeType type, float val)
    {
        switch (type)
        {
            case eUpgradeType.jump:
                jumpActive = true;
                GameController.instance.jumpActive = true;
                Debug.Log("Jump Power get!!!");
                //Fade-in Layer 1
                StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade1, 2f, 1));
                //Play the Chonk Collect Upgrade SFX
                audioSource.PlayOneShot(audioClipArray[1], 1f);
                break;
            case eUpgradeType.sink:
                sinkActive = true;
                Debug.Log("Sink Power get!!!");
                //Fade-in Layer 3
                StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade3, 2f, 1));
                //Play the Chonk Collect Upgrade SFX
                audioSource.PlayOneShot(audioClipArray[1], 1f);
                break;
            case eUpgradeType.swim:
                swimActive = true;
                Debug.Log("Swim Power get!!!");
                //Fade-in Layer 4
                StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade4, 2f, 1));
                //Play the Chonk Collect Upgrade SFX
                audioSource.PlayOneShot(audioClipArray[1], 1f);
                break;
            case eUpgradeType.squeeze:
                squeezeActive = true;
                Debug.Log("Squeeze Power get!!!");
                //Fade-in Layer 2
                StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade2, 2f, 1));
                //Play the Chonk Collect Upgrade SFX
                audioSource.PlayOneShot(audioClipArray[1], 1f);
                break;
            case eUpgradeType.climb:
                climbActive = true;
                Debug.Log("Climb Power get!!!");
                //Fade-in Layer 5
                StartCoroutine(FadeMixerGroup.StartFade(musicMixer, layerFade5, 2f, 1));
                //Play the Chonk Collect Upgrade SFX
                audioSource.PlayOneShot(audioClipArray[1], 1f);
                break;
            case eUpgradeType.health:
                healthManager.maxHealth += val;
                healthManager.Heal(0);
                healthPickups.Add(val);
                Debug.Log("Max health increased by " + val);
                //Play the Chonk Collect Health SFX
                audioSource.PlayOneShot(audioClipArray[0], 1f);
                break;
            case eUpgradeType.speed:
                //Integrate with the speed variable
                speedPickups.Add(val);
                break;
            default:
                break;
        }
    }

    //Flatten guts to a pancake
    public void Squeeze()
    {
        foreach (Transform child in gutsChildren)
        {
            if (child != guts)
                child.localScale = gutsSizeMin;
        }
    }

    //Return to normal size
    public void UnSqueeze()
    {
        foreach (Transform child in gutsChildren)
        {
            if (child != guts)
                child.localScale = gutsSizeMax;
        }
    }
}

