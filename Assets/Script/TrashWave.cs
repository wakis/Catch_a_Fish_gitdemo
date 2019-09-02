using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashWave : MonoBehaviour{
    [SerializeField] private float StartCreateTime = 5.0f;    //ゴミ生成時間
    [SerializeField] private float NextCreateTime = 20.0f;    //2回目以降のゴミ生成時間
    [SerializeField, Header("X軸のゴミ生成範囲の最小値")] private int minX = -300;
    [SerializeField,Header("X軸のゴミ生成範囲の最大値")] private int maxX = -430;
    private float startTime;
    [SerializeField, Header("最大生成個数")] private int trashNum;
    //[SerializeField] private float posX=10f;
    [SerializeField, Header("ごみの種類")] public int trashCount;
    private int count=0;

    [SerializeField, Header("ゴミリスト")]List<GameObject> trashRig = new List<GameObject>();

    //GameObject[] g = GameObject.FindGameObjectsWithTag("Trash");

    // Start is called before the first frame update
    void Start()
    {
        foreach (var obj in trashRig)
        {
            obj.AddComponent<Rigidbody>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (trashCount >= 0)
        {
            startTime += Time.deltaTime;
            if (startTime >= StartCreateTime)
            {
                for (int x = 0; x < trashNum; x++)
                {
                    Vector3 pos2 = new Vector3(Random.Range(minX, maxX), (float)0.32, Random.Range(-30, 270));    //Vector3(x,y,z)
                    var obj = Instantiate(trashRig[Random.Range(0, trashCount)], pos2, Quaternion.identity);
                    obj.gameObject.AddComponent<TrashMove>();

                   
                }
                startTime = 0;
                StartCreateTime = NextCreateTime;
                count++;
            }
        }else {
            Debug.Log("ゴミのobject情報が不足しています");
        }
    }
}
