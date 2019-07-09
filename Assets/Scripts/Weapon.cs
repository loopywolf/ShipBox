using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }//Update

    void Shoot()
    {
        Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        SoundManagerScript.playSound("laser");
    }//F
}
