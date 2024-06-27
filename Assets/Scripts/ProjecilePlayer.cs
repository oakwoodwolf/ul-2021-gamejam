using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecilePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask Enemy;
    public float projectileForce = 5f;
    public float projectileTimer = 10f;
    void Start()
    {
        
    }

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
        if (other.tag == "Enemy")
            {
                GameObject.Destroy(gameObject);
            }
        if (other.tag == "Health")
        {
            GameObject.Destroy(gameObject);
        }
    }

}
