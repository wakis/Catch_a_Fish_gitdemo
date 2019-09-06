using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPosFixation : MonoBehaviour
{
    private int randomX,randomZ,count=0;   
    private Rigidbody rigid;
    TrashMove script;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Trash" || col.gameObject.tag == "Plastic_cup")
        {
            Debug.Log("ゴミが触れたので位置を調整しました");
            script = this.gameObject.GetComponent<TrashMove>();
            script.TrashChangeY(-0.00001f);
            randomX = Random.Range(0, 3);
            randomZ = Random.Range(0, 4);
            Vector3 pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x + randomX * 2, TrashSpawner.CopyPosY, pos.z + randomZ);
            Stop();
            count++;
            //Debug.Log(count);
        }

    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Trash" || col.gameObject.tag == "Plastic_cup")
        {
            script = this.gameObject.GetComponent<TrashMove>();
            script.TrashChangeY(-0.00001f);
            Vector3 pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x + randomX * 2, TrashSpawner.CopyPosY, pos.z + randomZ);
            Stop();
            count = 0;
            Debug.Log("objectが離れました");
        }
    }

    void Stop()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }
}
