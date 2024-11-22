using System.Collections.Generic;
using UnityEngine;
public class CraftMannager : MonoBehaviour
{
    private Inventory inventoryRef;
    public static CraftMannager instance;
    //Bombas
    [SerializeField] public int countOilToBomb;
    [SerializeField] public int countbloodToBomb;
    [SerializeField] public int countfireToBomb;
    public List<int> bombs;
    //Potas
    [SerializeField] public int countOilToHealthPotion;
    [SerializeField] public int countBloodToHealthPotion;
    [SerializeField] public int countFireToHealthPotion;
    public List <int> healthPotions;
    //ShieldPotion
    [SerializeField] public int countOilToShieldPotion;
    [SerializeField] public int countBloodToShieldPotion;
    [SerializeField] public int countFireToHShieldPotion;
    public List<int> shieldPotions;

    //Sound
    [SerializeField] AudioClip craftBomb;
    [SerializeField] AudioClip craftPotion;
    [SerializeField] AudioClip craftSpecialBullets;

    private AudioSource audiosource;
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
        bombs = new List<int>();
        healthPotions = new List<int>();
        shieldPotions = new List<int>();
    }
    private void Start()
    {
        audiosource = GetComponent<AudioSource>();

        inventoryRef = Inventory.instance;
        //Bombas
        countOilToBomb = 5;
        countbloodToBomb = 10;
        countfireToBomb = 8;
        //Potas
        countOilToHealthPotion = 0;
        countBloodToHealthPotion = 20;
        countFireToHealthPotion = 0;
        //Escudos
        countOilToShieldPotion = 50;
        countBloodToShieldPotion = 0;
        countFireToHShieldPotion = 100;
    }
    private void Update()
    {
        GetItems();
    }
    public void CraftBomb()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToBomb && inventoryRef.GetBloodCount() >= countbloodToBomb && inventoryRef.GetFireCount() >= countfireToBomb)
        {
            // Reproducir sonido de activación
            if (audiosource != null && craftBomb != null)
            {
                audiosource.PlayOneShot(craftBomb);
            }
            
            bombs.Add(1);
            print($"Bombas Creadas: {bombs.Count}");
            inventoryRef.RemoveOil(countOilToBomb);
            inventoryRef.RemoveBlood(countbloodToBomb);
            inventoryRef.RemoveFire(countfireToBomb);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToBomb} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countbloodToBomb} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countfireToBomb} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    public void CraftHealthPotion()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToHealthPotion && inventoryRef.GetBloodCount() >= countBloodToHealthPotion && inventoryRef.GetFireCount() >= countFireToHealthPotion)
        {
            if (audiosource != null && craftPotion != null)
            {
                audiosource.PlayOneShot(craftPotion);
            }
            healthPotions.Add(1);
            print($"Pociones Creadas: {healthPotions.Count}");
            inventoryRef.RemoveOil(countOilToHealthPotion);
            inventoryRef.RemoveBlood(countBloodToHealthPotion);
            inventoryRef.RemoveFire(countFireToHealthPotion);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToHealthPotion} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countBloodToHealthPotion} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countFireToHealthPotion} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    public void CraftShieldPotion()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToShieldPotion && inventoryRef.GetBloodCount() >= countBloodToShieldPotion && inventoryRef.GetFireCount() >= countFireToHShieldPotion)
        {
            if (audiosource != null && craftSpecialBullets != null)
            {
                audiosource.PlayOneShot(craftSpecialBullets);
            }
            shieldPotions.Add(1);
            print($"escudos Creados: {shieldPotions.Count}");
            inventoryRef.RemoveOil(countOilToShieldPotion);
            inventoryRef.RemoveBlood(countBloodToShieldPotion);
            inventoryRef.RemoveFire(countFireToHShieldPotion);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToShieldPotion} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countBloodToShieldPotion} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countFireToHShieldPotion} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    private void GetItems()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            print($"usted tiene {bombs.Count} bombas.");
            print($"usted tiene {healthPotions.Count} Pociones de salud.");
            print($"usted tiene {shieldPotions.Count} Pociones de escudo.");
        }
    }
    //GettersRapidos
    public int GETBOMBS{get => bombs.Count; }
    public int GETPOTION{get => healthPotions.Count; }
    public int GETSHIELDS{get => shieldPotions.Count; }
}
