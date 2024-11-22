using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishTeleporter : MonoBehaviour
{
    public GameObject Respawner;
    private void Start()
    {
        Respawner = GameObject.Find("SpawnEnemiesFinish");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Respawner == null)
        {
            print(collision.name);
            SceneManager.LoadScene(2);
        }
    }
}
