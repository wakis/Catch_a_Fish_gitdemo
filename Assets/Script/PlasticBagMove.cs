using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagMove : MonoBehaviour
{
    private float posZ=0.04f,accelerationX=0.005f;
    private float time = 0, YMoveSwitchTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= YMoveSwitchTime)
        {
            accelerationX = -accelerationX;
            time = 0f;
        }
        this.gameObject.transform.Translate(0, accelerationX, -posZ);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fixation")   //Fixationに触れたらY軸固定
        {
            accelerationX = 0;
            Vector3 pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x, -2f, pos.z);
        }
    }

    public void PosZ_zero()
    {
        posZ = 0;
    }
}
