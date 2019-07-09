using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfieldMaster : MonoBehaviour
{
    public Starfield[] fields;
    //Camera mainCamera;
    public Transform shipLink; //link to ship's transform

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        fields[0].setPosition(-1, 0); 
        fields[1].setPosition(0, 0);
        fields[2].setPosition(1, 0);

        fields[3].setPosition(-1, 1); 
        fields[4].setPosition(0, 1);
        fields[5].setPosition(1, 1);

        fields[6].setPosition(-1, -1); 
        fields[7].setPosition(0, -1);
        fields[8].setPosition(1, -1);
    }//Start

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < fields.Length; i++) {
            fields[i].followTheShip(shipLink);
        }//for

    }//Update

}
