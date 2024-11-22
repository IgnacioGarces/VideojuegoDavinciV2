using UnityEngine;
public class Teleport : MonoBehaviour
{
    public Transform teleportDestination;
    public GameObject Respawner;
    private void Start()
    {
        Respawner = GameObject.Find("SpawnEnemies");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Respawner == null)
        {
            print(collision.name);
            collision.transform.position = teleportDestination.position;
        }
    }
}
