using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private float accelerationY = 0.015f,posZ=0.033f;
    private float time;
    private float YMoveSwitchTime=2.5f; //上下移動切り替えの時間
    private float random;
    private bool Move=true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        enabled = false;
        time = 0f;
        random = Random.Range(0f, 3f);  //遅延秒数ランダム設定
        yield return new WaitForSeconds (random);    //処理遅延秒数        
        //Debug.Log(random+"秒遅延");
        enabled = true; //enapledがtrueになったらUpdate実行
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (getY() == -0.00001f)
        {
            TrashChangeY(0.015f);
            time = 0f;

            Debug.Log("ゴミ同士が接触しました");
        }
        else if (getY() == 0.08f)
        {
            time = 0f;
        }

        if (time >= YMoveSwitchTime)
        {
            accelerationY = -accelerationY;
            time = 0f;
        }
        if (Move)
        {
            this.gameObject.transform.Translate(0, accelerationY, -posZ);
        }
    }

    public void posZ_zero()
    {
        posZ = 0;
    }

    public void TrashChangeY(float Y)
    {
        accelerationY = Y;
    }

    public float getY()
    {
        return accelerationY;
    }

    public float getZ()
    {
        return posZ;
    }

    public void TCahageMove()   //MoveがfalseになるとUpdateのtransform.Translateを変更を停止します
    {
        Move = !Move;
    }
}
