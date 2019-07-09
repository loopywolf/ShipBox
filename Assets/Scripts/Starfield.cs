using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Starfield : MonoBehaviour
{
    public int MaxStars = 100;
    public float StarSize = 0.1f;
    public float StarSizeRange = 0.5f;
    public float FieldWidth = 20f;
    public float FieldHeight = 25f;
    public bool Colorize = false;
    public float xOffset;
    public float yOffset;
    Camera theCamera;
    Vector3 ScreenDimensions;
    public Transform myTransform;

    ParticleSystem Particles;
    ParticleSystem.Particle[] Stars;

    private void Start()
    {
        theCamera = Camera.main;

        ScreenDimensions = theCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        //Debug.Log("dimensions " + ScreenDimensions); //hi

        FieldWidth = ScreenDimensions.x * 2.0f;
        FieldHeight = ScreenDimensions.y * 2.0f;

        Stars = new ParticleSystem.Particle[MaxStars];
        Particles = GetComponent<ParticleSystem>();

        Assert.IsNotNull(Particles, "Particle system missing from object!");

        xOffset = FieldWidth * 0.5f;                                                                                                        // Offset the coordinates to distribute the spread
        yOffset = FieldHeight * 0.5f;                                                                                                       // around the object's center

        for (int i = 0; i < MaxStars; i++)
        {
            float randSize = Random.Range(StarSizeRange, StarSizeRange + 1f);                       // Randomize star size within parameters
            float scaledColor = (true == Colorize) ? randSize - StarSizeRange : 1f;         // If coloration is desired, color based on size

            Stars[i].position = GetRandomInRectangle(FieldWidth, FieldHeight) + transform.position;
            Stars[i].startSize = StarSize * randSize;
            Stars[i].startColor = new Color(1f, scaledColor, scaledColor, 1f);
        }
        Particles.SetParticles(Stars, Stars.Length);                                                                // Write data to the particle system
    }//Start

    // GetRandomInRectangle
    // Get a random value within a certain rectangle area
    Vector3 GetRandomInRectangle(float width, float height)
    {
        float x = Random.Range(0, width);
        float y = Random.Range(0, height);
        return new Vector3(x - xOffset, y - yOffset, 0);
    }//F

/*    void Update()
    {
        bool update = false;

        for (int i = 0; i < MaxStars; i++)
        {
            Vector3 pos = Stars[i].position + transform.position; //actual position, through transform is 0,0,0
            
            Vector3 screenPoint = theCamera.WorldToScreenPoint( pos );
//            Debug.Log("screen x "+screenPoint.x);
            //is it offscreen to the left?
            if (screenPoint.x < 0)
            {
                Debug.Log("offscreen Left");
                Stars[i].position = new Vector3(
                    Stars[i].position.x + FieldWidth,
                    Stars[i].position.y,
                    Stars[i].position.z);
                //Debug.Log(Screen.width);
                update = true;
            }

            if (screenPoint.y < 0)
            {
                Debug.Log("offscreen down");
                Stars[i].position = new Vector3(
                    Stars[i].position.x,
                    Stars[i].position.y + FieldHeight,
                    Stars[i].position.z);
                //Debug.Log(Screen.width);
                update = true;
            }

            //Stars[i].position = pos - transform.position;
        }//for

        if (update)
        {
            Particles.SetParticles(Stars, Stars.Length);
            Debug.Log("update stars");
        }//if

    }//Update */

    public void setPosition(float x,float y)
    {
        myTransform.position = new Vector3(x * FieldWidth, y * FieldHeight, 0);
    }//F

    public void followTheShip(Transform ship)
    {
        Vector3 newPos = new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.z);
        bool updated = false;

        //offscreen left
        if( transform.position.x < ship.position.x - 1.5f * FieldWidth)
        {
            newPos.x = transform.position.x + 3.0f * FieldWidth;
            updated = true;
            //Debug.Log("it jumped to the right.");
        } else 
        //offscreen right
        if( transform.position.x > ship.position.x + 1.5f * FieldWidth)
        {
            newPos.x = transform.position.x - 3.0f * FieldWidth;
            updated = true;
            //Debug.Log("it jumped to the left.");
        }//if - left and right

        if (transform.position.y < ship.position.y - 1.5f * FieldHeight)
        {
            newPos.y = transform.position.y + 3.0f * FieldHeight;
            updated = true;
            //Debug.Log("it jumped down.");
        }
        else
        if (transform.position.y > ship.position.y + 1.5f * FieldHeight)
        {
            newPos.y = transform.position.y - 3.0f * FieldHeight;
            updated = true;
            //Debug.Log("it jumped up.");
        }//if - left and right

        if (updated)
            transform.position = newPos;
    }//F

}//class

