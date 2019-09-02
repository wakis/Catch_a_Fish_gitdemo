using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookatcamera : MonoBehaviour
{
    Camera mains;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera obj in UnityEngine.Object.FindObjectsOfType(typeof(Camera)))
        {
            mains = obj;
        }
            transform.LookAt(mains.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
