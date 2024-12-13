using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public int damage = 10;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            var RefPlayer = collision.gameObject.GetComponent<Health>();
            if (RefPlayer != null)
            {
                RefPlayer.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}
