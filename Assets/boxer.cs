using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxer : MonoBehaviour
{
    [SerializeField]
    GameObject opener;
    bool open = false;
    public bool next = false;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        next = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (open&& opener.transform.localEulerAngles.x<75f)
        {
            var ea= opener.transform.localEulerAngles;
            ea.x += 75f * Time.deltaTime;
            opener.transform.localEulerAngles = ea;
            next = true;
        }
    }

    public void open_box()
    {
        Debug.Log("ok");
        if (Input.GetKeyDown(KeyCode.V)||Lotsignal.open)
        {
            open = true;
        }
    }
}
