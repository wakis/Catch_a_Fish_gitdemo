using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seter : MonoBehaviour
{
    SpriteRenderer sr = new SpriteRenderer();
    float c = 1f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0f,0f,0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (c>0f)
        {
            c -= Time.deltaTime * 1f/2f;
        }
        else
        {
            c = 0f;
        }
        sr.color = new Color(0f,0f,0f, c);
    }
}
