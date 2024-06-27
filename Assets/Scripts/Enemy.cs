using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Object Explosion;
    public Object OrangeShield;
    public Object EvilBullet;
    public Collider hitbox;
    public Material[] material;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip pew;
    [SerializeField] private AudioClip kaboom;
    public float moveSpeed;
    public int EnemyHealth;
    public int currentColor;
    public bool canShoot;
    public float shootTimer = 0.5f;
    Renderer render;
    public static Vector3 PlayerTransform;

    void Start()
    {
        PlayerTransform = new Vector3(0f, 0f, 0f);
        Randomiser();
        render = GetComponent<Renderer>();
        render.sharedMaterial = material[currentColor]; 
        switch (currentColor)
        {
            case 0:
                EnemyHealth = 1;
                moveSpeed = 5f;
                canShoot = false;
                break;
            case 1:
                EnemyHealth = 5;
                moveSpeed = 4f;
                canShoot = false;
                break;
            case 2:
                EnemyHealth = 1;
                moveSpeed = 3f;
                canShoot = true;
                break;
            case 3:
                EnemyHealth = 1;
                moveSpeed = 4f;
                canShoot = true;
                break;
            case 4:
                EnemyHealth = 1;
                moveSpeed = 10f;
                canShoot = false;
                break;
            default:
                EnemyHealth = 1;
                moveSpeed = 3f;
                canShoot = false;
                break;
        }
    }
    public void Randomiser()
    {
        currentColor = Random.Range(0, 6);
    }
    // Update is called once per frame
    void Update()
    {
        render.sharedMaterial = material[currentColor];
        if (currentColor > 6)  currentColor = 0;
        if (PlayerController.isDead == false)
        {
            switch (currentColor)
            {
                case 0:
                    transform.LookAt(PlayerTransform, Vector3.up);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
                case 1:
                    transform.LookAt(PlayerTransform, Vector3.up);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
                case 2:
                    shootTimer -= Time.deltaTime;
                    if (shootTimer <= 0) ShootPlayer();
                    transform.LookAt(PlayerTransform, Vector3.up);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
                case 3:
                    shootTimer -= Time.deltaTime;
                    if (shootTimer <= 0) ShootPlayer();
                    transform.localScale = new Vector3(0.5f, 1, 0.5f);
                    transform.Rotate(0, 1, 0);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
                case 5:
                    transform.localScale += new Vector3(0.01f, 0.005f, 0.01f);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
                default:
                    transform.LookAt(PlayerTransform, Vector3.up);
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
                    break;
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerProjectile")
        {
            EnemyHealth -= 1;
            GameObject.Destroy(other);
            Debug.Log(EnemyHealth);
            if (EnemyHealth <= 0) Death(); else GameObject.Instantiate(OrangeShield, transform.position, transform.rotation);

        }
        if (other.tag == "Player")
        {
            transform.Translate(Vector3.back * moveSpeed * 100 * Time.deltaTime);
        }
    }

    private void Death()
    {
        Debug.Log("Hit!");
        GameManager.scoreValue++;
        audio.PlayOneShot(kaboom);
        GameObject.Instantiate(Explosion, transform.position, transform.rotation);
        GameObject.Destroy(gameObject);
    }
    private void ShootPlayer()
    {
        GameObject.Instantiate(EvilBullet, transform.position, transform.rotation);
        audio.PlayOneShot(pew);
        shootTimer = 0.5f;
    }
}
