using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using wakis.fishObj;
using UnityEngine.SceneManagement;

public class PlayingGameRule : MonoBehaviour
{
    public getfishlist fishobj;
    public enum playingStep{//増やしたらturn()をいじる
        NON=-1,
        START,
        CAST,
        STAY,
        HIT,
        PRINT,
        AGAIN,
        RESULT,
    };
    
    [SerializeField, EnumListLabel(typeof(playingStep))]
    GameObject[] gameruler;//ゲームルールリスト(順番あり)
    List<Ipgamerule> nowrule = new List<Ipgamerule>();

    playingStep nowstep;
    public playingStep getstep { get { return nowstep; } }
    playingStep nextstep;

    int fishnum=0;
    [SerializeField]
    int fishQuotaNum;
    [NonSerialized]
    public GameObject hitobj;
    [NonSerialized]
    public List<GameObject> washitobj=new List<GameObject>();
    public int num { get { return (fishnum - fishQuotaNum); } }

    List<GameObject> visionlist = new List<GameObject>();

    //Start用関数
    void setGRlist()
    {
        for (int lp=0;lp<= (int)Enum.GetValues(typeof(playingStep)).Cast<playingStep>().Max(); lp++)
        {
            if (gameruler[lp] == null)
            {
                gameruler[lp] = new GameObject("Type_" + ((playingStep)Enum.ToObject(typeof(playingStep), lp)).ToString());
            }
            if (gameruler[lp].GetComponent<Ipgamerule>() == null)
            {
                Debug.Log("null");
                gameruler[lp].AddComponent<defaulpgr>();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        washitobj.Clear();
        fishnum = 0;
        nextstep = 0;
        nowstep = playingStep.NON;
        //Debug.Log("miss");
        setGRlist();
        hitobj = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        turn();
    }

    void turn()
    {
        if (nowstep != nextstep)//切り替え処理
        {
            nowstep = nextstep;
            if (nextstep==playingStep.AGAIN)
            {
                var x= Camera.main.transform.position;
                var lister = Instantiate(hitobj, new Vector3(-10f + ((fishnum-1f)*2f*0f), 5f-(fishnum - 1f)*2f, -12f)+ x, Quaternion.Euler(0, 0, 0));
                //Destroy(lister.GetComponent<outName>());
                Destroy(lister.GetComponent<nonResultsize>());
                //lister.transform.LookAt(Camera.main.transform.position*(1f),Vector3.up);
                lister.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                visionlist.Add(lister);
                lister.transform.position = new Vector3(-10f + (fishnum - 1f) * 3f*0f, 5f - (fishnum - 1f)*2f, 12f) + x;
            }
            if (nextstep==playingStep.RESULT)
            {
                visionobj();
            }
            foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
            {
                pgr.pGame_Start_event();
            }
        }

        switch (nowstep)
        {
            case playingStep.START:
                Debug.Log("START処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    nextstep = nowstep + pgr.pGame_Update_event();
                }
                break;
            case playingStep.CAST:
                Debug.Log("CAST処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    nextstep = nowstep + pgr.pGame_Update_event();
                }
                break;
            case playingStep.STAY:
                Debug.Log("STAY処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    nextstep = nowstep + pgr.pGame_Update_event();
                }
                break;
            case playingStep.HIT:
                Debug.Log("HIT処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    nextstep = nowstep + pgr.pGame_Update_event();
                }
                break;
            case playingStep.PRINT:
                Debug.Log("PRINT処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    nextstep = nowstep + pgr.pGame_Update_event();
                }
                if (nextstep == nowstep + 1)
                {
                    washitobj.Add(hitobj);
                    fishnum++;
                }
                if (fishnum>=fishQuotaNum)
                {
                    nextstep = Enum.GetValues(typeof(playingStep)).Cast<playingStep>().Max();
                }
                break;
            case playingStep.AGAIN:
                Debug.Log("AGAIN処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    if (pgr.pGame_Update_event() > 0)
                    {
                        nextstep = (playingStep)1;
                    }
                }
                break;
            case playingStep.RESULT:
                Debug.Log("RESULT処理");
                foreach (var pgr in gameruler[(int)nowstep].GetComponents<Ipgamerule>())
                {
                    if (pgr.pGame_Update_event()>0)
                    {
                        SceneManager.LoadScene("result");
                        //nextstep = playingStep.NON;
                    }
                }
                break;
            default:
                Debug.Log("END");
                break;
        }
        //visionrot();
    }
    void visionobj()
    {
        foreach (var obj in visionlist)
        {
            Destroy(obj);
        }
    }
    void visionrot()
    {
        if (visionlist.Count <= 0) return;
        foreach (var obj in visionlist)
        {
            if (obj == null) return;
            var t=obj.transform.eulerAngles;
            t.y++;
            obj.transform.eulerAngles = t;
        }
    }
}
