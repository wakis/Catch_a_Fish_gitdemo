using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoAt : MonoBehaviour, Ipgamerule
{
    GameObject hitobj;
    [SerializeField]
    AudioClip[] sounde=new AudioClip[2];
    AudioSource audios;
    AudioSource addaud;
    bool sethit;
    PlayingGameRule gamerule;
    float timer;
    [SerializeField]
    AdCAST sao;
    bool vib;
    bool nonup;

    [SerializeField]
    GameObject uki;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().enabled = false;
        sethit = false;
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
        Destroy(uki);
        audios.PlayOneShot(sounde[0]);
        hitobj = new GameObject();
        sethit = false;
        timer = 0f;
        if (!GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        do {
            gamerule.hitobj = gamerule.fishobj.hitobj(Random.Range(0, gamerule.fishobj.listps()) + Random.value);
            Debug.Log(gamerule.hitobj);
        } while (gamerule.hitobj.tag=="fish"&&gamerule.num<-1);
        Lotsignal.byWrite(true);
        vib = true;
        nonup = true;
    }
    public int pGame_Update_event()
    {
        if (nonup)
        {
            if (timer > 0.3f && timer < 0.5f && vib)
            {
                vib = !vib;
                Lotsignal.byWrite(vib);
            }
            else if (timer > 0.5f && timer < 0.8f && !vib)
            {
                vib = !vib;
                Lotsignal.byWrite(vib);
            }
            else if (timer > 0.8f && timer < 1.1f && vib)
            {
                vib = !vib;
                Lotsignal.byWrite(vib);
            }
            else if (timer > 1.1f && timer < 1.4f && !vib)
            {
                vib = !vib;
                Lotsignal.byWrite(vib);
            }
            else if (timer > 1.4f && timer < 1.5f && vib)
            {
                vib = !vib;
                Lotsignal.byWrite(vib);
            }
        }
        if (hitobj.transform.eulerAngles != new Vector3(0f, 0f, 0f)) hitobj.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        timer += Time.deltaTime;
        if (!sethit) {
            if (timer > 1.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                Lotsignal.byWrite(false);
                return -1;
            }
            if (Input.GetKeyDown(KeyCode.Space) || playerup())
            {
                hitup();
                GetComponent<SpriteRenderer>().enabled = false;
                sethit = true;
                Lotsignal.byWrite(true);
            }
            return 0;
        }
        else if (sethit && hitobj.GetComponent<Rigidbody>().velocity.y <70f&& hitobj.transform.position.y>3f)
        {
            Lotsignal.byWrite(false);
            Destroy(hitobj);
            Destroy(addaud);
            return 1;
        }
        else return 0;
    }

    void hitup()
    {
        nonup = false;
        sao.castoff();
        if (hitobj != null) Destroy(hitobj);
        addaud = gameObject.AddComponent<AudioSource>();
        hitobj = Instantiate(gamerule.hitobj, new Vector3(0f, -10f, 160f), Quaternion.Euler(0f, 0f, 0f));
        hitobj.transform.localScale = new Vector3(1f, 1f, 1f)*3f;
        Debug.Log(hitobj.transform.eulerAngles);
        audios.PlayOneShot(sounde[2]);
        addaud.volume = 0.5f;
        addaud.PlayOneShot(sounde[1]);
        var hitrb = hitobj.AddComponent<Rigidbody>();
        hitrb.AddForce((hitrb.transform.up*1.5f - hitrb.transform.forward*1f) * 3000f);
        //hitrb.useGravity = false;
    }

    bool playerup()
    {
        if (Lotsignal.pointX[10]-Lotsignal.pointX[9] > 100) return true;
        return false;
    }
}
