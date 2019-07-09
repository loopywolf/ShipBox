using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    Quaternion rotation;
    public Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Awake is called at the start
    void Awake()
    {
        rotation = transform.rotation;
    }//awake

    void LateUpdate()
    {
        transform.rotation = rotation;
    }//LateUpdate

}//class
