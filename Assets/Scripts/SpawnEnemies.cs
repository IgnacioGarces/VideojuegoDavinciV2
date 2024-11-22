using System.Collections;
using UnityEngine;
public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawn;
    [SerializeField] float spawnTime = 2f;  // Tiempo de espera entre apariciones
    [SerializeField] int distance = 11;
    bool onRange;
    Transform player;
    [SerializeField] int health = 2;
    void Start()
    {
        // Obtener referencia al jugador
        player = GameManager.instance.player.transform;

        // Comenzar la corutina para respawnear enemigos
        StartCoroutine(Respawn());
    }
    void Update()
    {
        // Verificar si el jugador está en rango
        if (player == null) return;
        if (Vector2.Distance(transform.position, player.position) <= distance)
        {
            onRange = true;
        }
        else
        {
            onRange = false;
        }

        if (health<= 0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Infligir daño al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
                playerController.TakeKnockback(transform.up * 12);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }
    #region Spawn
    // Corutina para reaparecer enemigos
    IEnumerator Respawn()
    {
        while (true)  // Loop infinito para que siga corriendo indefinidamente
        {
            if (onRange)  // Si el jugador está en rango, se genera un enemigo
            {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = enemySpawn.position;

                // Posicionar al enemigo de manera aleatoria en el eje X
                Vector2 enemyMovement = enemy.transform.position;
                enemyMovement.x = Random.Range(-6, 6);
                enemy.transform.position = enemyMovement;
            }

            // Esperar el tiempo antes de reaparecer otro enemigo
            yield return new WaitForSeconds(spawnTime);
        }
    }
    #endregion
}
