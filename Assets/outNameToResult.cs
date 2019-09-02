using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class outNameToResult : MonoBehaviour
{
    [SerializeField]
    GameObject text;
    [SerializeField]
    string thisname;
    GameObject texerobj;
    GameObject nullobj;
    Camera mains;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() != null || SceneManager.GetActiveScene().name == "result")
        {
            return;
        }
        if (thisname == null || thisname == "")
        {
            thisname = gameObject.name;
        }
        texerobj = Instantiate(text, transform);
        texerobj.SetActive(false);
        texerobj.GetComponent<TextMesh>().text = thisname;
        foreach (Camera obj in UnityEngine.Object.FindObjectsOfType(typeof(Camera)))
        {
            mains = obj;
        }
        nullobj = new GameObject();
        //nullobj.transform.parent = transform;
        nullobj.transform.position = transform.position;
        var tex = texerobj.transform.lossyScale;
        var ave = (tex.x + tex.y + tex.z) / 3f;
        texerobj.transform.localScale = tex * 0.1f / ave;
        texerobj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>() != null || SceneManager.GetActiveScene().name == "result")
        {
            return;
        }
        /* nullobj.transform.LookAt(mains.transform);
         var transer = nullobj.transform.eulerAngles;
         transer.y -= transer.y;
         transer.z = transer.x = 0f;
         texerobj.transform.eulerAngles = transer;*/
        //texerobj.transform.LookAt(texerobj.transform.position - mains.transform.position - mains.transform.eulerAngles);
        texerobj.transform.eulerAngles=new Vector3(0f,180f,0f);
    }
}
