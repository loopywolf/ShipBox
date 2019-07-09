using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip laserSound; //others
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        laserSound = Resources.Load<AudioClip>("NFF-laser");
        //others
        audioSrc = GetComponent<AudioSource>();
    }//Start 

    // Update is called once per frame
    void Update()
    {
        
    }//Update

    public static void playSound(string clip)
    {
        switch(clip)
        {
            case "laser":
                audioSrc.PlayOneShot(laserSound);
                break;
        }//switch

    }//F

}//class
