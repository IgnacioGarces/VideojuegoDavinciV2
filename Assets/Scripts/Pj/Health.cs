using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public HealthBar healtBar;
    //Variables de Vida mavima y actual
    public int maxHealth = 100;
    public int currentHealth;
    //Variables para el color de danio
    SpriteRenderer spriteRenderer;
    Color originalPlayerColor;
    void Start()
    {
        //Actualizo vida actual con vida maxima
        currentHealth = maxHealth;
        healtBar.SetmaxHealth(maxHealth);
        //Guardo el componente del sprite del jugador en la variable
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            //Guardo el color original del jugador
            originalPlayerColor = spriteRenderer.color;
        }
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Corrutina que me ayuda a esperar x cantidad de tiempo para cambiar de un color a otro
        StartCoroutine(ChangeColorOnDamage());
        healtBar.SetHealth(currentHealth);
        if (currentHealth<=0)
        {
            Die();
        }

    }
    public void RestoreLife(int life)
    {
        currentHealth += life;
        healtBar.SetHealth(currentHealth);
    }
    /*#region 
        IEnumerator es una interfaz que define cómo iterar sobre una colección de elementos. 
        En C#, se usa en combinación con yield para implementar una secuencia que puede ser iterada uno a uno. 
        Un objeto que implementa IEnumerator permite recorrer una colección (como una lista o una secuencia generada por yield) 
        y acceder a sus elementos en orden.

    #endregion*/
    private IEnumerator ChangeColorOnDamage() 
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;

            /*#region 
                yield = 'devolver'
                
                Indica que una función o método generará una serie de valores en lugar de devolver un solo resultado. 
                En lugar de devolver todos los resultados a la vez, yield permite que la función devuelva un valor y luego reanude su ejecución 
                desde el punto en el que se detuvo, permitiendo la iteración perezosa.

            #endregion*/
            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = originalPlayerColor;
        }
    }
    private void Die()
    {
        Debug.Log("THE PLAYER HAS DIED");
        if (gameObject != null)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene(3);
        }
    }
}
