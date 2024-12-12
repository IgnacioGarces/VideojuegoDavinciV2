using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float detonationTime = 0.1f;  // Tiempo antes de la explosi�n
    public float explotionTime = 4f;
    public GameObject explosionEffect;  // Prefab de la explosi�n
    public float gasDamage = 100f;
    public float explosionRadius = 2f;   // Radio de la explosi�n
    [SerializeField] private GameObject explosionRadiusIndicator; // El prefab del indicador del radio de la explosi�n
    private GameObject explosionEffectIndicator;

    public LayerMask enemyLayer;  // Filtrar enemigos

    private void Start()
    {
        // Instanciar el indicador de radio de la explosi�n
        explosionEffectIndicator = Instantiate(explosionRadiusIndicator, transform.position, Quaternion.identity);

        // Aseg�rate de que el indicador est� posicionado correctamente
        explosionEffectIndicator.transform.position = transform.position;

        // Ajustar la escala del indicador seg�n el radio
        explosionEffectIndicator.transform.localScale = new Vector3(explosionRadius * 2, explosionRadius * 2, 1);

        
    }

    public void DetonateBomb()
    {
        StartCoroutine(ExplosionCountdown());   
    }

    private IEnumerator ExplosionCountdown()
    {
        yield return new WaitForSeconds(detonationTime);
        Explode();
    }

    private void Explode()
    {
        StartCoroutine(EffectBomb());
        
    }
    private IEnumerator EffectBomb() 
    {
        // Crear el efecto de explosi�n
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Causar da�o en el �rea de la explosi�n
        CauseDamageInArea();

        yield return new WaitForSeconds(explotionTime);
        // Destruir la bomba
        Destroy(gameObject);
        Destroy(explosionEffectIndicator);
    }
    private void CauseDamageInArea()
    {
        // Detectar enemigos dentro del radio de la explosi�n
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBehavior enemy = collider.GetComponent<EnemyBehavior>();
                if (enemy != null)
                {
                    enemy.TakePoisonDamage(gasDamage); // Ajustar el da�o por veneno
                }
            }
        }
    }

}