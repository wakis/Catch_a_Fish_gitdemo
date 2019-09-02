using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestroy : MonoBehaviour
{
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
        if (col.gameObject.tag == "Trash")
        {
            Destroy(col.gameObject);
            Debug.Log("ゴミが飛んだので消去しました");
        }
    }
}
