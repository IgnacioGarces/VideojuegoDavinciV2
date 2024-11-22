using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<int> oil;
    public List<int> blood;
    public List<int> fire;

    
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        
        oil = new List<int>();
        blood = new List<int>();
        fire = new List<int>();
    }
    private void Update()
    {
        PruebaItemsAdd();
    }

    public void AddMaterial(Material.MATERIALS materialType) 
    {
        int materialCount = Random.Range(10, 50);
        switch (materialType)
        {
            case Material.MATERIALS.BLOOD:
                for (int i = 0; i < materialCount; i++)
                {
                    blood.Add(1);
                }
                break;
            case Material.MATERIALS.OIL:
                for (int i = 0; i < materialCount; i++)
                {
                    oil.Add(1);
                }
                break;
            case Material.MATERIALS.FIRE:
                for (int i = 0; i < materialCount; i++)
                {
                    fire.Add(1);
                }
                break;
        }
    }



    public void PruebaItemsAdd()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddOil();
            AddBlood();
            AddFire();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            print($"Total Aceite: {GetOilCount()}");
            print($"Total sangre: {GetBloodCount()}");
            print($"Total Fuego: {GetFireCount()}");
        }
    }
    public void AddOil()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            oil.Add(count);
        }
        print($"Conseguiste {count} de Aceite");
    }
    public void AddBlood()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            blood.Add(count);
        }
        print($"Conseguiste {count} de Sangre");
    }
    public void AddFire()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            fire.Add(count);
        }
        print($"Conseguiste {count} de Fuego");
    }

    public int RemoveOil(int necessaryAmount)
    {
        if(oil.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                oil.RemoveAt(0);
            }
            print($"La nueva count de aceite es de {oil.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente aceite ya que necesitas {necessaryAmount} y La count de aceite disponible es de {oil.Count}");
            return 0;
        }
    }
    public int RemoveBlood(int necessaryAmount)
    {
        if (blood.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                blood.RemoveAt(0);
            }
            print($"La nueva count de sangre es de {blood.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente sangre ya que necesitas {necessaryAmount} y La count de aceite disponible es de {blood.Count}");
            return 0;
        }
    }
    public int RemoveFire(int necessaryAmount)
    {
        if (fire.Count >= necessaryAmount)
        {
            for (int i = 0; i < necessaryAmount; i++)
            {
                fire.RemoveAt(0);
            }
            print($"La nueva count de aceite es de {fire.Count}");
            return necessaryAmount;
        }
        else
        {
            print($"No tienes suficiente aceite ya que necesitas {necessaryAmount} y La count de aceite disponible es de {fire.Count}");
            return 0;
        }
    }
    public int GetOilCount()
    {
        return oil.Count;
    }
    public int GetBloodCount()
    {
        return blood.Count;
    }
    public int GetFireCount()
    {
        return fire.Count;
    }


    //ESTA FUNCION EN EL FUTURO REEMPLAZA LAS TRES DE ADDX ME QUEDO UN XD TRISTE PERO NO ERA LA INTENCION SIU.
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Material"))
    //    {
    //        materialCount++;
    //    }
    //}
}
