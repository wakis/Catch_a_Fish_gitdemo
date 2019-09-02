using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoRe : MonoBehaviour, Ipgamerule
{
    [SerializeField]
    AdCAST ad;
    List<GameObject> rez=new List<GameObject>();
    PlayingGameRule gamerule;
    float timerset = 3f;
    float timer = 0f;
    [SerializeField]
    List<GameObject> objls = new List<GameObject>();
    [SerializeField]
    boxer boxer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
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
        ad.off();
        timer = 0f;
    }
    public int pGame_Update_event()
    {
        timer += Time.deltaTime;
        if (timer< timerset)
        {
            var transq = Camera.main.transform.eulerAngles;
            var transp = Camera.main.transform.position;
            transq.y -= (90f / timerset) * Time.deltaTime;
            transq.x += (70f / timerset) * Time.deltaTime;
            transp.x += 0.1f*Time.deltaTime;
            transp.y += 0.2f * Time.deltaTime;
            Camera.main.transform.eulerAngles = transq;
            Camera.main.transform.position = transp;
        }else
        {
            boxer.open_box();
        }
        foreach (var obj in rez)
        {
            Vector3 rot = obj.transform.eulerAngles;
            rot.y++;
            //obj.transform.eulerAngles = rot;
        }
        if (boxer.next) {

            if (!GetComponent<SpriteRenderer>().enabled)
            {
                int count = 0;
                foreach (var obj in gamerule.washitobj)
                {
                    float y = count * 15f / (gamerule.washitobj.Count - 1f);
                    var on = Instantiate(obj);
                    on.GetComponent<outName>().Result = true;
                    on.SetActive(false);
                    //Destroy(on.GetComponent<nonResultsize>());
                    Debug.Log("Des");
                    on.transform.position = objls[count].transform.position;
                    on.transform.eulerAngles = objls[count].transform.eulerAngles;
                    on.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    rez.Add(on);
                    count++;
                    on.SetActive(true);
                }
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || Lotsignal.boolB)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                return 1;
            }
        }
        return 0;
    }
}