using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public float scrollSpeed_X = 0.5f;
    public float scrollSpeed_Y = 0.5f;
    public Material mat;
    void Start()
    {
        mat = GetComponent<Material>();
    }
    void Update()
    {
        //transform.localPosition += new Vector3(0f, -0.02f, -0.1f); ;
        float offsetX = Time.deltaTime * scrollSpeed_X;
        float offsetY = Time.deltaTime * scrollSpeed_Y;
        mat.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
