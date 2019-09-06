using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixationArea : MonoBehaviour
{
    TrashMove Tscript;
    PlasticBagMove Pscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trash" || col.gameObject.tag == "Plastic_cup")   //Trashに触れたら指定ポイントに再設置しY軸上昇
        {
            Tscript = col.gameObject.GetComponent<TrashMove>();
            Tscript.TrashChangeY(0.008f);
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 1.6f, pos.z);    //2.1
        }
        if (col.gameObject.tag == "PlasticBag")   //PlasticBagに触れたらY軸固定
        {
            Pscript = col.gameObject.GetComponent<PlasticBagMove>();
            Pscript.PlasticBagChangeX(0);
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 1.7f, pos.z);
        }
    }
}
