﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class outName : MonoBehaviour
{
    [SerializeField]
    GameObject text;
    [SerializeField,Multiline]
    string thisname;
    GameObject texerobj;
    GameObject nullobj;
    Camera mains;
    [System.NonSerialized]
    public bool Result = false;
    [System.NonSerialized]
    public int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Rigidbody>() != null|| SceneManager.GetActiveScene().name == "result")
        {
            return;
        }
        if(thisname==null|| thisname == "")
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
        if (Result)
        {
            texerobj.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            switch (num) {
                case 0: texerobj.transform.localPosition = new Vector3(1.4f,-1f,0f);
                    break;
                case 1:
                    texerobj.transform.localPosition = new Vector3(-1.6f, -1f, 0f);
                    break;
                case 2:
                    texerobj.transform.localPosition = new Vector3(0f, 2f, 0f);
                    break;
            }
            Debug.Log("res");
        }
        else texerobj.transform.LookAt(texerobj.transform.position - mains.transform.position - mains.transform.eulerAngles);
        if (gameObject.GetComponent<Rigidbody>() != null || SceneManager.GetActiveScene().name == "result")
        {
            return;
        }
        /* nullobj.transform.LookAt(mains.transform);
         var transer = nullobj.transform.eulerAngles;
         transer.y -= transer.y;
         transer.z = transer.x = 0f;
         texerobj.transform.eulerAngles = transer;*/
    }
}
