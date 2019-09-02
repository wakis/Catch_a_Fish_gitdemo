using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoStay : MonoBehaviour, Ipgamerule
{
    float timer;
    [SerializeField]
    float mintimeline;
    [SerializeField]
    float maxtimeline;
    float timeline;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timeline = Random.Range(mintimeline,maxtimeline);
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pGame_Start_event()
    {
        if (!GetComponent<SpriteRenderer>().enabled)
        {
            timer = 0;
            timeline = Random.Range(mintimeline, maxtimeline);
            //GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public int pGame_Update_event()
    {
        timer += Time.deltaTime;
        if (timer > timeline)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            return 1;
        }
        else return 0;
    }
}
