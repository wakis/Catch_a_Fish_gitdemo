using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforth : MonoBehaviour
{
    public float f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce((Vector3.forward+ Vector3.up) *f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
