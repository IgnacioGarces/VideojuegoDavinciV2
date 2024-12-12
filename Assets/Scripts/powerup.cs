using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    
    public GameObject pickupEffect;
    public float multp = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
   

        Destroy(gameObject);
    }
}
