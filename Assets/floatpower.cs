using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatpower : MonoBehaviour
{
    Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y<-1f)
        {
            if (rig.velocity.y < 0f)
            {
                rig.velocity = new Vector3(0f,0f,0f);
            }
            rig.AddForce(transform.up * 10f);
            rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
    }
}
