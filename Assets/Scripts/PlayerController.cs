using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    
    public Camera cam;
    public Object PlayerBullet;
    public AudioSource src;
    public AudioClip shoot;
    public AudioClip boomy;
    public static bool isDead = false;
    public Object Explosion;
    public static int PlayerHealth = 6;
    public float invFrames = 3f;
    public GameObject DeathUI;
    // Update is called once per frame
    private void Awake()
    {
        isDead = false;
        PlayerHealth = 6;
    }
    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!isDead)
            {
                GameObject.Instantiate(PlayerBullet, transform.position, transform.rotation);
                src.PlayOneShot(shoot);
            }

            }
    }
    void FixedUpdate()
    {
        // Converting the mouse position to a point in 3D-space
        Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        // Using some math to calculate the point of intersection between the line going through the camera and the mouse position with the XZ-Plane
        float t = cam.transform.position.y / (cam.transform.position.y - point.y);
        Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, 0, t * (point.z - cam.transform.position.z) + cam.transform.position.z);
        //Rotating the object to that point
        if (!isDead) transform.LookAt(finalPoint, Vector3.up);

        

        //Handle invincibility frames
        invFrames -= Time.deltaTime;
        if (invFrames < 0) invFrames = 0f;
        //Debug.Log("Invincibility Frames:" + invFrames);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && invFrames == 0f)
        {
            PlayerHealth -= 1;
            invFrames = 1f;
            Debug.Log("Ouch" + PlayerHealth);
            if (PlayerHealth == 0) PlayerDeath();
        }
        if (other.tag == "Health")
        {
            PlayerHealth += 1;
            GameObject.Destroy(other);
        }
    }
    public void PlayerDeath()
    {
        DeathUI.SetActive(true);
        isDead = true;
        src.PlayOneShot(boomy);
        GameObject.Instantiate(Explosion, transform.position, transform.rotation);
        float respawnTimer = 2f;
        Debug.Log(respawnTimer);
        respawnTimer -= Time.deltaTime;
        if (respawnTimer <= 0f) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
