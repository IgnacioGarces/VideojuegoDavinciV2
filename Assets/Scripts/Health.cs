using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //Variables de Vida mavima y actual
    public int maxHealth = 100;
    public int currentHealth;

    //Variables para el color de danio
    SpriteRenderer spriteRenderer;
    Color originalPlayerColor;

    public HealthBar healthBar; //variable para la barra de vida

    void Start()
    {
        //Actualizo vida actual con vida maxima
        currentHealth = maxHealth;
        healthBar.SetmaxHealth(maxHealth); //pasa la vida maxima a la barra de vida al iniciar

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

        if (currentHealth<=0)
        {
            Die();
        }

        healthBar.SetHealth(currentHealth); //le paso la vida actual a la barra de vida
    }

    /*#region 
        IEnumerator es una interfaz que define c�mo iterar sobre una colecci�n de elementos. 
        En C#, se usa en combinaci�n con yield para implementar una secuencia que puede ser iterada uno a uno. 
        Un objeto que implementa IEnumerator permite recorrer una colecci�n (como una lista o una secuencia generada por yield) 
        y acceder a sus elementos en orden.

    #endregion*/
    private IEnumerator ChangeColorOnDamage() 
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;

            /*#region 
                yield = 'devolver'
                
                Indica que una funci�n o m�todo generar� una serie de valores en lugar de devolver un solo resultado. 
                En lugar de devolver todos los resultados a la vez, yield permite que la funci�n devuelva un valor y luego reanude su ejecuci�n 
                desde el punto en el que se detuvo, permitiendo la iteraci�n perezosa.

            #endregion*/
            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = originalPlayerColor;
        }
    }

    private void Die()
    {
        Debug.Log("THE PLAYER HAS DIED");
    }
   
}
