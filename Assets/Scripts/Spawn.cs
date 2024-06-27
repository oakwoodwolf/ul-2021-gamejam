using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public float SpawnTimer = Random.Range(1.5f, 5f);
    public Object Enemy;

    // Update is called once per frame
    void Update()
    {
        Vector3 SpawnPos = new Vector3(Random.Range(-10, 11), 0, Random.Range(9f, 11.5f));
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0)
        {
            GameObject.Instantiate(Enemy, SpawnPos, transform.rotation);
            float spawnTimer = Random.Range(1.5f, 5f);
}
    }
}
