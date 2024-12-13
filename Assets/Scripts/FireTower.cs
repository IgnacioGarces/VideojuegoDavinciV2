using System.Collections;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;  // Prefab del proyectil
    [SerializeField] Transform bulletSpawn;   // Punto de aparici�n del proyectil
    public float spawnTime = 5f;              // Tiempo entre disparos

    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        while (true)
        {
            // Instanciar el proyectil en la posici�n y rotaci�n del spawn
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            yield return new WaitForSeconds(spawnTime); 
        }
    }
}
