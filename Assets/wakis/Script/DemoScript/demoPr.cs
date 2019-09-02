using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoPr : MonoBehaviour, Ipgamerule
{
    PlayingGameRule gamerule;
    GameObject thisone;
    float posy;
    [SerializeField]
    AudioClip[] sounde=new AudioClip[2];
    AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().enabled = false;
        foreach (PlayingGameRule obj in UnityEngine.Object.FindObjectsOfType(typeof(PlayingGameRule)))
        {
            gamerule = obj;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pGame_Start_event()
    {
        posy = 6f;
        if (!GetComponent<SpriteRenderer>().enabled)
        {
           GetComponent<SpriteRenderer>().enabled = true;
        }
        thisone = Instantiate(gamerule.hitobj);
        thisone.transform.position = new Vector3(0, 10f, -3f);
        thisone.transform.localScale = new Vector3(1f, 1f, 1f);
        thisone.transform.eulerAngles = Vector3.zero;
        if(thisone.tag=="fish")audios.PlayOneShot(sounde[0]);
        else audios.PlayOneShot(sounde[1]);
    }
    public int pGame_Update_event()
    {
        if (posy>1f) posy -= 8f*Time.deltaTime;
        thisone.transform.position = new Vector3(0, posy, -3f);
        Vector3 rot = thisone.transform.eulerAngles;
        rot.y++;
        rot.x = rot.z = 0f;
        thisone.transform.eulerAngles = rot;
        if (Input.GetKeyDown(KeyCode.Space) || Lotsignal.boolB)
        {
            Destroy(thisone);
            GetComponent<SpriteRenderer>().enabled = false;
            return 1;
        }
        else return 0;
    }
}
