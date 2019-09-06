using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPosArea : MonoBehaviour
{
    private float random;
    TrashMove script;
    PlasticBagMove PScript;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Trash" || col.gameObject.tag == "Plastic_cup")  //ゴミのZ移動停止
        {
            random = Random.Range(0f, 2.7f);
            StartCoroutine(DelayMethod(random, col.gameObject));
        }
        if (col.gameObject.tag == "PlasticBag")  //ゴミのZ移動停止
        {
            random = Random.Range(0.5f, 2.5f);
            StartCoroutine(PlasticDelayMethod(random, col.gameObject));
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 1.85f, pos.z);
        }
    }

    private IEnumerator DelayMethod(float waitTime, GameObject col)
    {
        yield return new WaitForSeconds(waitTime);
        if(col.gameObject)
        {
            script = col.GetComponent<TrashMove>();
            script.posZ_zero();
            col.gameObject.transform.Translate(0, script.getY(), script.getZ());
            script.TCahageMove();
        }
        else { Debug.Log("参照したGameObjectは消去されたため一部の実行を停止しました"); }
    }

    private IEnumerator PlasticDelayMethod(float waitTime, GameObject col)
    {
        yield return new WaitForSeconds(waitTime);
        if (col.gameObject)
        {
            PScript = col.GetComponent<PlasticBagMove>();
            PScript.PosZ_zero();
            PScript.PCahageMove();
        }
        else { Debug.Log("参照したGameObjectは消去されたため一部の実行を停止しました"); }
    }
}



