using System.Collections;
using System;
using UnityEngine;

public class demoCas : MonoBehaviour, Ipgamerule
{
    [SerializeField]
    AudioClip[] sounde = new AudioClip[2];
    AudioSource audios;
    [SerializeField]
    AdCAST sao;
    [SerializeField]
    GameObject uki;
    [NonSerialized]
    public GameObject any;
    PlayingGameRule gamerule;
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
        sao.caster();
        if (!GetComponent<SpriteRenderer>().enabled)
        {
            any = Instantiate(uki) ;
            any.transform.position = transform.position;
            any.GetComponent<Rigidbody>().velocity = (Quaternion.Euler(transform.eulerAngles) * new Vector3(0f, 0.3f, 0.8f) * 50f);
            audios.PlayOneShot(sounde[0]);
            //GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public int pGame_Update_event()
    {
        if (any != null && any.transform.position.y < -1f)
        {
            audios.PlayOneShot(sounde[1]);
            Destroy(any);
            GetComponent<SpriteRenderer>().enabled = false;
            Lotsignal.byWrite(false);
            return 1;
        }
        else
        {
            Lotsignal.byWrite(true);
            return 0;
        }
    }
}