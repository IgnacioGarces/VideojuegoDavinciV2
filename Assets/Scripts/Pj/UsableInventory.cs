using UnityEngine;
public class UsableInventory : MonoBehaviour
{
    private CraftMannager CraftRef;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] Transform bombSpawn;
    private Health healtRef;
    public int healtRestore;
    private AudioSource audiosource;
    [SerializeField] AudioClip usePotion;
    [SerializeField] AudioClip useBomb;
    aim refAim;
    private void Start()
    {
        CraftRef = CraftMannager.instance;
        healtRef = GameObject.FindAnyObjectByType<Health>();
        healtRestore = 20;
        refAim = GameObject.FindAnyObjectByType<aim>();
        audiosource = GetComponent<AudioSource>();
    }
    void Update()
    {
        UseBomb();
        UsePotion();
        UseSpecialBullets();
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
                audiosource.PlayOneShot(useBomb);
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
                CraftRef.healthPotions.RemoveAt(0);
                audiosource.PlayOneShot(usePotion);
                healtRef.RestoreLife(healtRestore);
            }
            else
            {
                print("No tenes pociones");
            }
        }
    }
    public void UseSpecialBullets()
    {
        if (CraftRef == null) return;
        if (CraftRef.SpecialBullets.Count > 0)
        {
            refAim.HAVESPECIALBULLET = true;
        }
        else
        {
            refAim.HAVESPECIALBULLET = false;
        }
    }
}
