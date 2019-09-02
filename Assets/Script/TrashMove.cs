using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    private float accelerationY = 0.015f,posZ=0.04f;
    private float time;
    private float YMoveSwitchTime=2.5f; //上下移動切り替えの時間
    private float random;

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
        if (time >= YMoveSwitchTime)
        {
            if (getY() == -0.00001f)
            {
                changeY(-0.015f);
                time = 0.8f;
            }
            //Debug.Log(accelerationY);
            accelerationY = -accelerationY;
            time = 0f;
        }
        this.gameObject.transform.Translate(0, accelerationY, -posZ);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Fixation")   //Fixationに触れたらY軸固定
        {
            accelerationY = 0;
            Vector3 pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x, TrashSpawner.CopyPosY + 2.1f, pos.z);
        }
    }

    public void posZ_zero()
    {
        posZ = 0;
    }

    public void changeY(float Y)
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
}
