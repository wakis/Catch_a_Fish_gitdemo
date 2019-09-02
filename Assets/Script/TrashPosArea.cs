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
        if (col.gameObject.tag == "Trash")  //ゴミの横移動停止
        {
            random = Random.Range(0f, 2.5f);
            if (col.gameObject)
            {
                StartCoroutine(DelayMethod(random, col.gameObject));
            }
            else { Debug.Log("GameObjectは消去されました"); }
    }
        if (col.gameObject.tag == "PlasticBag")  //ゴミの横移動停止
        {
            random = Random.Range(0f, 2.1f);
            StartCoroutine(PlasticDelayMethod(random, col.gameObject));
            Vector3 pos = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(pos.x, -2f, pos.z);
        }
    }

    private IEnumerator DelayMethod(float waitTime, GameObject col)
    {
            yield return new WaitForSeconds(waitTime);
            script = col.GetComponent<TrashMove>();
            script.posZ_zero();
            col.gameObject.transform.Translate(0, script.getY(), script.getZ());
    }

    private IEnumerator PlasticDelayMethod(float waitTime, GameObject col)
    {
        yield return new WaitForSeconds(waitTime);
        PScript = col.GetComponent<PlasticBagMove>();
        PScript.PosZ_zero();
    }
}



