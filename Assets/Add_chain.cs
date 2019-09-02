using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_chain : MonoBehaviour
{
    [ContextMenuItem("Set chain", "chains")]
    public int chain;
    List<Rigidbody> Jointlist = new List<Rigidbody>();
    void chains()
    {
        if (Jointlist != null)
        {
          Jointlist.Clear();
        }
        if (chain>2&& GetComponent<HingeJoint>()==true)
        {
            float longs = Mathf.Abs(
                GetComponent<HingeJoint>().connectedBody.transform.localPosition.y - transform.localPosition.y);
            Jointlist.Add(gameObject.GetComponent<Rigidbody>());
            for (int lp=2;lp< chain;lp++)
            {
                var obj = Instantiate(gameObject);
                obj.name = name + ":" + lp.ToString();
                obj.transform.parent = transform.parent;
                var pos = obj.transform.localPosition;
                pos.y -= longs * lp;
                obj.transform.localPosition = pos;
                obj.GetComponent<HingeJoint>().connectedBody = Jointlist[Jointlist.Count-1];
                Jointlist.Add(obj.GetComponent<Rigidbody>());
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
