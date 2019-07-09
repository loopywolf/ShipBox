using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject ImpactPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }//start

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("hit " + hitInfo.name);
        Box b = hitInfo.GetComponent<Box>();
        Instantiate(ImpactPrefab, transform.position, Quaternion.identity);
        if (b!=null)
        {
            b.TakeDamage(damage);
        }//not null
        Destroy(gameObject);
    }//OnTriggerEnter2D

}//class
