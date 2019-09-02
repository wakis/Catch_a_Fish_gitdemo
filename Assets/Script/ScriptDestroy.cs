using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDestroy : MonoBehaviour {

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
                Destroy(col.gameObject.GetComponent<TrashPosFixation>());
            }
            else { Debug.Log("GameObjectは消去されました"); }
        }
        if (col.gameObject.tag == "PlasticBag")  //ゴミの横移動停止
        {
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, -2f, pos.z);
        }
    }
}
