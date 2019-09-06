using UnityEngine;
using System.Collections;

public class TextLayer : MonoBehaviour
{
    TextMesh tm;

    // Use this for initialization
    void Start()
    {
        tm = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Lotsignal.openum[0] <= 0)
        {
            tm.text = "ボックスを閉じて\n[L]キーを押して";
        }else if(Lotsignal.openum[1] <= 0)
        {
            tm.text = "ボックスを開いて\n[L]キーを押して";
        }
        else
        {
            tm.text = "";
            transform.parent.gameObject.SetActive(false);
        }
    }
}