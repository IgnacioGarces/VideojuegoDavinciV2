using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    
    public GameObject pickupEffect;
    public float multp = 1.5f;
    public float duration = 3f;

    private AudioSource audioSource;
    [SerializeField] AudioClip pickUp;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource != null && pickUp != null)
            {
                audioSource.PlayOneShot(pickUp);
            }
          StartCoroutine ( Pickup(other));
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerController stats = player.GetComponent<PlayerController>();
        stats.movementVelocity *= multp;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        stats.movementVelocity /= multp;
        Destroy(gameObject);
    }
}
