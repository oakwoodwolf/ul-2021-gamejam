using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecileEvil : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Player;
    public float projectileForce = 5f;
    public float projectileTimer = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * projectileForce * Time.deltaTime);
        //rb.AddForce(Vector3.forward * projectileForce);
        projectileTimer -= Time.deltaTime;
        if (projectileTimer < 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "PlayerProjectile")
        {
            GameObject.Destroy(gameObject);
        }
    }

}