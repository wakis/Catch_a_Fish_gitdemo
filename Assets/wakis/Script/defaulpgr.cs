using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaulpgr : MonoBehaviour, Ipgamerule
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pGame_Start_event()
    {

    }

    public int pGame_Update_event()
    {
        if (Input.GetKeyDown(KeyCode.Space)) return 1;
        else return 0;
    }
}
