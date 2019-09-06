using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageObjectPositionGet : MonoBehaviour
{
    private Vector3 PositionY;
    // Start is called before the first frame update
    void Start()
    {
        PositionY = this.transform.position;
        Debug.Log(PositionY.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float StagePosition_GetY()
    {
        return PositionY.y;
    }
}
