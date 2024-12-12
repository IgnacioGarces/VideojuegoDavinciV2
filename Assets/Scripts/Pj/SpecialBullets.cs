using UnityEngine;
public class SpecialBullets : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] float lifeTime;
    void Start()
    {
        damage = 100;
        speed = 10;
        Destroy(gameObject,lifeTime);
    }

    // Update is called once per frame
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
        }
    }
}
