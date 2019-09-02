using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private float StartCreateTime = 5.0f;    //初期のゴミ生成時間
    [SerializeField] private float NextCreateTime = 20.0f;    //2回目以降のゴミ生成時間
    private float startTime;
    private int TimeCount=0,timeOut=80;
    private float CreateTime;   //ゴミ生成時間の代入先
    [SerializeField, Header("X軸のゴミ生成範囲をマイナス方向にいくつ広げるか"+"(符号は付けないでください)")] private int minX = 50;
    [SerializeField, Header("X軸のゴミ生成範囲をプラス方向にいくつ広げるか")] private int maxX = 50;
    [SerializeField, Header("Z軸のゴミ生成範囲をマイナス方向にいくつ広げるか"+"(符号は付けないでください)")] private int minZ = 50;
    [SerializeField, Header("Z軸のゴミ生成範囲をプラス方向にいくつ広げるか")] private int maxZ = 50;
    [SerializeField, Header("Y軸のゴミ生成ポジション")] private float posY = -2.5f;
    public static float CopyPosY;
    private int Angle,random;
    [SerializeField, Header("初期生成個数")] private int StartTrashNum;
    [SerializeField, Header("最大生成個数")] private int trashNum;
    private float TrashRemnants;

    [SerializeField, Header("ゴミリスト")] List<Rigidbody> trashRig = new List<Rigidbody>();
    [SerializeField, Header("角度調整ゴミリスト")] List<Rigidbody> trashAngleRig = new List<Rigidbody>();
    [SerializeField, Header("ゴミスポナーリスト")] List<Rigidbody> trashSpawnerRig = new List<Rigidbody>();
    [SerializeField, Header("初期配置ゴミリスト")] List<Rigidbody> startTrashSetRig = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        startTime = 0f;
        CopyPosY = posY;
        CreateTime = StartCreateTime;

        if (trashRig.Count >= 1)    //trashRigにobjctが入っているか
        {
            for (int i = 0; i < startTrashSetRig.Count; i++)     //それぞれのスポーンごとに1回のみ生成
            {
                Vector3 SpawnerPos = startTrashSetRig[i].transform.position;     //スポーンの座標を取得
                for (int x = 0; x < StartTrashNum; x++)      //ごみを生成
                {
                    Angle = Random.Range(-30, 30);
                    Vector3 pos = new Vector3(Random.Range(SpawnerPos.x - minX, SpawnerPos.x + maxX), CopyPosY, Random.Range(SpawnerPos.z - minZ, SpawnerPos.z + maxZ));    //Vector3(x,y,z)
                    var obj = Instantiate(trashRig[Random.Range(0, trashRig.Count)], pos, Quaternion.AngleAxis(Angle, Vector3.forward));
                    obj.gameObject.AddComponent<TrashMove>();
                    if (x % 3 == 0)
                    {
                        trashAngleCreate(SpawnerPos);
                    }
                }
            }
        }
        else
        {
            Debug.Log("ゴミのobject情報が不足しています");
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (trashRig.Count >= 0)    //trashRigにobjctが入っているか
        {
                startTime += Time.deltaTime;
            if (startTime >= CreateTime)    //ゴミ生成時間突入
            {
                for (int i = 0; i < trashSpawnerRig.Count; i++)     //それぞれのスポーンごとに随時生成
                {
                    Vector3 SpawnerPos = trashSpawnerRig[i].transform.position;     //スポーンの座標を取得
                    for (int x = 0; x < trashNum; x++)      //ごみを生成
                    {
                        Angle = Random.Range(-30, 30);
                        Vector3 pos = new Vector3(Random.Range(SpawnerPos.x - minX, SpawnerPos.x + maxX), posY, Random.Range(SpawnerPos.z - minZ, SpawnerPos.z + maxZ));    //Vector3(x,y,z)
                        var obj = Instantiate(trashRig[Random.Range(0, trashRig.Count)], pos, Quaternion.AngleAxis(Angle, Vector3.forward));
                        obj.gameObject.AddComponent<TrashMove>();
                        if (x % 3 == 0)
                        {
                            trashAngleCreate(SpawnerPos);
                        }
                    }
                }
                startTime = 0;
                CreateTime = NextCreateTime;    //ゴミの生成時間をNextCreateTimeに変更
                TimeCount += 20;
                if (TimeCount == timeOut) { CreateTime = 999; Debug.Log("ゴミの生成を終了します"); }
            }
        }
        else
        {
            Debug.Log("ゴミのobject情報が不足しています");
        }
    }

    private void trashAngleCreate(Vector3 SpawnerPos)
    {
        if (trashAngleRig.Count >= 1)
        {
            Angle = Random.Range(-90, -45);
            random = Random.Range(0,1+1);
            if (random == 0) { Angle *= -1; }
            Vector3 pos = new Vector3(Random.Range(SpawnerPos.x - minX, SpawnerPos.x + maxX), posY, Random.Range(SpawnerPos.z - minZ, SpawnerPos.z + maxZ));    //Vector3(x,y,z)
            Quaternion rot = Quaternion.Euler(0, 0, Angle);
            var obj = Instantiate(trashAngleRig[Random.Range(0, trashAngleRig.Count)], pos,rot);
            obj.gameObject.AddComponent<PlasticBagMove>();
        }
        else
        {
            Debug.Log("角度設定済みのゴミのobject情報が不足しています");
        }
    }
}