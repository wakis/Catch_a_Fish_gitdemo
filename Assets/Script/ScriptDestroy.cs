using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDestroy : MonoBehaviour {
    TrashMove Tscript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trash")  
        {
            if (col.gameObject)
            {
                Tscript = col.gameObject.GetComponent<TrashMove>();
                Tscript.TrashChangeY(0);    //Y軸の上昇値を0に設定
                Vector3 pos = col.gameObject.transform.position;
                col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 2.1f, pos.z);
                Destroy(col.gameObject.GetComponent<TrashPosFixation>());
            }
            else { Debug.Log("GameObjectは消去されました"); }
        }
        if (col.gameObject.tag == "Plastic_cup")
        {
            Tscript = col.gameObject.GetComponent<TrashMove>();
            Tscript.TrashChangeY(0);    //Y軸の上昇値を0に設定
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 1.9f, pos.z);
            Destroy(col.gameObject.GetComponent<TrashPosFixation>());

        }
        if (col.gameObject.tag == "PlasticBag")  //ゴミの横移動停止
        {
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 1.8f, pos.z);
        }
    }
}
