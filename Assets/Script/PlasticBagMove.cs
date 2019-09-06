using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagMove : MonoBehaviour
{
    private float posZ=0.033f,accelerationX=0.005f;
    private float time = 0, YMoveSwitchTime = 2f;
    private bool Move=true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= YMoveSwitchTime)
        {
            accelerationX = -accelerationX;
            time = 0f;
        }
        if (Move)
        {
            this.gameObject.transform.Translate(0, accelerationX, -posZ);   //角度を変更しているためXとY座標の位置が違います
        }
    }

    public void PosZ_zero()
    {
        posZ = 0;
    }

    public void PlasticBagChangeX(float x)
    {
        accelerationX = x;
    }

    public void PCahageMove()   //MoveがfalseになるとUpdateのtransform.Translateを変更を停止します
    {
        Move = !Move;
    }
}
