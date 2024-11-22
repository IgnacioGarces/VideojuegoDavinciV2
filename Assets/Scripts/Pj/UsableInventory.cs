using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class UsableInventory : MonoBehaviour
{
    private CraftMannager CraftRef;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;
    private Health healtRef;
    public int healtRestore;
    private void Start()
    {
        CraftRef = CraftMannager.instance;
        healtRef = GameObject.FindAnyObjectByType<Health>();
        healtRestore = 20;
    }
    void Update()
    {
        UseBomb();
        UsePotion();
        UseShield();
    }
    public void UseBomb()
    {
        if(CraftRef == null) return;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(CraftRef.bombs.Count > 0)
            {
                CraftRef.bombs.RemoveAt(0);
                ThrowBomb();
            }
            else
            {
                print("No tenes bombas");
            }
        }
    }
    void ThrowBomb()
    {
        if (this != null)
        {
            //creo la bomba
            GameObject bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3 direction = (mouseWorldPos - bombSpawn.position).normalized;
            bomb.transform.up = direction;
            Bomb bombScript = bomb.GetComponent<Bomb>();
            if (bombScript != null)
            {
                bombScript.DetonateBomb();
            }
        }
    }
    public void UsePotion()
    {
        if (CraftRef == null) return;
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (CraftRef.healthPotions.Count > 0 && healtRef.currentHealth <=100)
            {
                healtRef.RestoreLife(healtRestore);
            }
            else
            {
                print("No tenes pociones");
            }
        }
    }
    public void UseShield()
    {
        if (CraftRef == null) return;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (CraftRef.shieldPotions.Count > 0)
            {
                CraftRef.shieldPotions.RemoveAt(0);
            }
            else
            {
                print("No tenes escudos");
            }
        }
    }
}
