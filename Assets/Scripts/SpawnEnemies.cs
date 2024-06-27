using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnEnemies : MonoBehaviour
{
    public float EnemySpawnTimer = Random.Range(0.5f, 5f);
    public float HealthSpawnTimer = Random.Range(5f, 15f);
    public Object Enemy;
    public Object Health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SpawnTimer);
        Vector3 SpawnPos = new Vector3(Random.Range(-10, 11), 0, Random.Range(9f, 11.5f));
        if (!PlayerController.isDead) {
            EnemySpawnTimer -= Time.deltaTime;
            HealthSpawnTimer -= Time.deltaTime;
        }
        if (EnemySpawnTimer <= 0)
        {
            GameObject.Instantiate(Enemy, SpawnPos, transform.rotation);
            EnemySpawnTimer = Random.Range(0.5f, 4f);
        }
        if (HealthSpawnTimer <= 0)
        {
            GameObject.Instantiate(Health, SpawnPos, transform.rotation);
            HealthSpawnTimer = Random.Range(6f, 20f);
        }
    }
    public void BackToMenu()
    {
        Debug.Log("I am here");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}

            
