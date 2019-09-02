using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nonResultsize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name!="result")
        {
            //transform.localScale = new Vector3(1f,1f,1f);
            Vector3 size = transform.localScale;
            transform.localScale = size * 1.8f;
        }else
        {
            //transform.localScale = new Vector3(1f, 1f, 1f);
            //Vector3 size = transform.localScale;
            //transform.localScale = size * 1.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
