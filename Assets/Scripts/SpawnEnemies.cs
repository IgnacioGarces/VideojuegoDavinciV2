using System.Collections;
using UnityEngine;
public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnTime = 2f;  // Tiempo de espera entre apariciones
    [SerializeField] int distance = 15;
    bool onRange;
    Transform player;
    [SerializeField] float health = 240f;
    void Start()
    {
        //enemySpawn = gameObject.transform.position;
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

        if (health <= 0 )
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
        Bullet bulletDamage = collision.gameObject.GetComponent<Bullet>();
        if (collision.gameObject.CompareTag("Bullet"))
        {
            
            health = health - bulletDamage.damage;
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
                
                Vector2 spawnPosition = spawnPoint.position;

                // Posicionar al enemigo de manera aleatoria en el eje X

                spawnPosition.x += Random.Range(-1, 1);
                enemy.transform.position = spawnPosition;
            }

            // Esperar el tiempo antes de reaparecer otro enemigo
            yield return new WaitForSeconds(spawnTime);
        }
    }
    #endregion
}
