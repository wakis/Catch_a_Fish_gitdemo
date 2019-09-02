using System;
using System.Collections.Generic;
using UnityEngine;
using wakis.fishObj;

public class test : MonoBehaviour
{
    List<FishElement> outlist = new List<FishElement>();
    [SerializeField]
    getfishlist fishobj;
    [SerializeField]
    Material notFind;
    int rlx = 4;
    int rlz = 4;

    // Start is called before the first frame update
    void Start()
    {
        if (fishobj == null|| notFind==null) return;
        outlist = fishobj.getFishList;
        resulttable();
    }

    void resulttable()
    {
        
        for (int LP = 0; LP < rlz; LP++)
        {
            for (int lp = 0; lp < rlx; lp++)
            {
                if ((outlist.Count<= LP * rlx + lp)) return ;
                var obj = Instantiate(outlist[LP * rlx + lp].fish);
                obj.transform.position = new Vector3(-7f  + lp * 2.5f * (float)(10 / rlx), 5f - LP *1.5f* (float)(10 / rlz), 1f);
                //obj.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                obj.AddComponent<Lookatcamera>();
                if(!outlist[LP * rlz + lp].hitter) setMaterial(obj);
            }
        }
    }

    void setMaterial(GameObject obj)//すべての子供ObjectのMaterialを非公開化
    {
        if (obj.GetComponent<Renderer>() != null)//Materialを非公開化
        {
            if (obj.GetComponent<SkinnedMeshRenderer>() != null)//階層Materialへのアクセス
            {
                int num = 0;
                List<Material> LSMR = new List<Material>();
                foreach (var mt in obj.GetComponent<SkinnedMeshRenderer>().materials)
                {
                    LSMR.Add(notFind);
                    num++;
                }
                obj.GetComponent<SkinnedMeshRenderer>().materials = LSMR.ToArray();
            }
            foreach (var mt in obj.GetComponents<Renderer>())
            {
                mt.material = notFind;
                List<Material> LSMR = new List<Material>();
                foreach(var mtr in mt.materials)
                {
                    LSMR.Add(notFind);
                }
                for (int lp=0;lp< mt.materials.Length;lp++)
                mt.materials = LSMR.ToArray();
            }
        }
        //子供検索開始
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            setMaterial(ob.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
