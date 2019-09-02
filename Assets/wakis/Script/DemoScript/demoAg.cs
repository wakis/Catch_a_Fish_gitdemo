using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoAg : MonoBehaviour, Ipgamerule
{
    PlayingGameRule gamerule;
    Vector3 setact;
    float timer;
    [SerializeField]
    Sprite[] Castlist = new Sprite[3];
    bool x = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void pGame_Start_event()
    {
        timer = 0;
        x = false;
        if (!GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    public int pGame_Update_event()
    {
        timer += Time.deltaTime;
        int t = (int)(timer - (timer % 1));
        GetComponent<SpriteRenderer>().sprite = Castlist[t % 3];
        if (Input.GetKeyDown(KeyCode.Space) || CAST())
        {
            GetComponent<SpriteRenderer>().enabled = false;
            Debug.Log("nexter");
            return 1;
        }
        else return 0;
    }
    bool CAST()
    {
        if (Lotsignal.boolB)
        {
            setact.x = Lotsignal.acceX;
            setact.y = Lotsignal.acceY;
            setact.z = Lotsignal.acceZ;
            x = true;
        }
        else if (Lotsignal.rostB&&x)
        {
            if (setact == null) Debug.Log("out");
            Debug.Log(setact);
            var vsact = new Vector3(Lotsignal.acceX, Lotsignal.acceY, Lotsignal.acceZ);
            Debug.Log("\t" + vsact);
            if (true)
            {
                if (setact.z<1) return false;
                vsact = setact;
                return true;
            }
            else
            {
                //vsact = Vector3.zero;
                //Debug.Log("miss");
            }
        }
        if (setact.z > Lotsignal.aveZ)
        {
            setact.z = Lotsignal.acceZ;
        }


        return false;
    }
}
