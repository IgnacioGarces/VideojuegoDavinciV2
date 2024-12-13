using UnityEngine;
public class aim : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject specialBulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] private bool haveSpecialBullet;
    private AudioSource audioSource;
    [SerializeField] AudioClip[] shootSound;
    private CraftMannager CraftRef;

    public float time;
    public float reloadTime;
    public int bulletAmount;
    public int maxBulletAmount = 6;


    void Start()
    {
        CraftRef = CraftMannager.instance;
        audioSource = GetComponent<AudioSource>();
        InputManager.instance.interactAction += Shoot;
       /* if (time > reloadTime && bulletAmount > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bulletAmount--;
                time = 0;
            }
        }else
        {
            time += Time.deltaTime;
        }*/
    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 fixedMousepos = new Vector3(mousePos.x, mousePos.y, 0);
        target.transform.position = fixedMousepos;

      //  if (input)
    }
    void FixedUpdate()
    {
        transform.up = (target.transform.position - transform.position).normalized;
    }

    void Shoot()
    {
        if (audioSource != null && shootSound != null)
        {
            int randomIndex = Random.Range(0, shootSound.Length);
            audioSource.PlayOneShot(shootSound[randomIndex]);
        }
        if (haveSpecialBullet)
        {
            GameObject bullet = Instantiate(specialBulletPrefab);
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
            CraftRef.SpecialBullets.RemoveAt(0);
        }
        else
        {
            if (this != null)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = bulletSpawn.position;
                bullet.transform.up = (target.transform.position - bulletSpawn.position).normalized;
            }
        }
    }

    public bool HAVESPECIALBULLET { get => haveSpecialBullet; set => haveSpecialBullet = value; }
}
