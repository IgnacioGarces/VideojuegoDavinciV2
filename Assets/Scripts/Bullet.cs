using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;
    public float damage;
    void Start()
    {
        Destroy(gameObject, lifetime);
        damage = 30f;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var RefEnemigo = collision.gameObject.GetComponent<EnemyBehavior>();
            if (RefEnemigo != null)
            {
                RefEnemigo.TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }
}

