using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 8f;
    private static int health = GameManager.health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PlayerProjectile")
        {
            health += 1;
            GameObject.Destroy(gameObject);
        }
    }
}
