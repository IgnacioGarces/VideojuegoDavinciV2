using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    //SpecialBullets
    [SerializeField] public int countOilToSpecialBullets;
    [SerializeField] public int countBloodToSpecialBullets;
    [SerializeField] public int countFireToSpecialBullets;
    public List<int> SpecialBullets;
    //Sound
    [SerializeField] AudioClip craftBomb;
    [SerializeField] AudioClip craftPotion;
    [SerializeField] AudioClip craftSpecialBullets;
    private AudioSource audiosource;
    //Buttons
    public Button craftBombButon;
    public Button craftHealthPotion;
    public Button craftSpecialBullet;
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
        SpecialBullets = new List<int>();
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
        //Balas
        countOilToSpecialBullets = 30;
        countBloodToSpecialBullets = 0;
        countFireToSpecialBullets = 30;
        //Buttons
        craftBombButon.onClick.AddListener(CraftBomb);
        craftHealthPotion.onClick.AddListener(CraftHealthPotion);
        craftSpecialBullet.onClick.AddListener(CraftSpecialBullets);
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
    public void CraftSpecialBullets()
    {
        if (inventoryRef == null) return;
        if (inventoryRef.GetOilCount() >= countOilToSpecialBullets && inventoryRef.GetBloodCount() >= countBloodToSpecialBullets && inventoryRef.GetFireCount() >= countFireToSpecialBullets)
        {
            if (audiosource != null && craftSpecialBullets != null)
            {
                audiosource.PlayOneShot(craftSpecialBullets);
            }
            SpecialBullets.Add(1);
            print($"escudos Creados: {SpecialBullets.Count}");
            inventoryRef.RemoveOil(countOilToSpecialBullets);
            inventoryRef.RemoveBlood(countBloodToSpecialBullets);
            inventoryRef.RemoveFire(countFireToSpecialBullets);
        }
        else
        {
            print("Materiales insuficientes");
            print($"Aceite requerido {countOilToSpecialBullets} / Disponible : {inventoryRef.GetOilCount()}");
            print($"Sangre requerida {countBloodToSpecialBullets} / Disponible : {inventoryRef.GetBloodCount()}");
            print($"Fuego requerido {countFireToSpecialBullets} / Disponible : {inventoryRef.GetFireCount()}");
        }
    }
    private void GetItems()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            print($"usted tiene {bombs.Count} bombas.");
            print($"usted tiene {healthPotions.Count} Pociones de salud.");
            print($"usted tiene {SpecialBullets.Count} Pociones de escudo.");
        }
    }
    //GettersRapidos
    public int GETBOMBS{get => bombs.Count; }
    public int GETPOTION{get => healthPotions.Count; }
    public int GETSPECIALBULLETS{get => SpecialBullets.Count; }
}
