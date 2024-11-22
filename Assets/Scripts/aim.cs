using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    public float coolDown;
    float lastShot;
    public int shootsLeft;
    private AudioSource audioSource;

    [SerializeField] AudioClip shootSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InputManager.instance.interactAction += Shoot;
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedMousepos = new Vector3(mousePos.x, mousePos.y, 0);
        target.transform.position = fixedMousepos;
    }
    void FixedUpdate()
    {
        transform.up = (target.transform.position - transform.position).normalized;
    }

    void Shoot()
    {
            if (this != null)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = bulletSpawn.position;
                bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
            }
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
   

}
