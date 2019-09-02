using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vision : MonoBehaviour
{
    PlayingGameRule gamerule;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PlayingGameRule obj in UnityEngine.Object.FindObjectsOfType(typeof(PlayingGameRule)))
        {
            gamerule = obj;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
