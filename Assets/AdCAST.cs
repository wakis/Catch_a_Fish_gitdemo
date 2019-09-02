using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdCAST : MonoBehaviour
{
    [SerializeField]
    GameObject sao;
    [SerializeField]
    Rigidbody tama;
    float timer;
    float ace;

    bool bl = false;
    int lotcase;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        ace = 1f;
        bl = false;
        //1-(X*X)
        lotcase = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bl);
        if (bl) {
            if (sao.transform.eulerAngles.x > 1f)
            {
                var angles = sao.transform.eulerAngles;
                angles.x -= 1f;
                sao.transform.eulerAngles = angles;
            }
            else
            {
                bl = false;
            }
        }
        lotmove();
    }
    void lotmove()
    {
        //if (lotcase != 0) lotcase = 0;
        if ((Lotsignal.acceY != 0&&Lotsignal.acceY > 350f) || Input.GetKeyDown(KeyCode.J))
        {
            lotcase = 1;
        }
        else if ((Lotsignal.acceY != 0 && Lotsignal.acceY < 650f) || Input.GetKeyDown(KeyCode.K))
        {
            lotcase = 2;
        }
        else
        {
            lotcase = 0;
        }

        switch (lotcase) {
            case 0:
                if (sao.transform.eulerAngles.z > 5f || sao.transform.eulerAngles.z < -5f)
                {
                    var saos = sao.transform.eulerAngles;
                    saos.z = 0;
                    sao.transform.eulerAngles = saos;
                }
                break;
            case 1:
                leftrun();
                break;
            case 2:
                rightrun();
                break;
        }
    }

    public void caster()
    {
        if (sao.transform.eulerAngles.x < 45f)
        {
            timer += Time.deltaTime * Time.deltaTime;
            ace = 1f - timer;
            var angles = sao.transform.eulerAngles;
            angles.x += 46f;
            sao.transform.eulerAngles = angles;
        }
    }

    void leftrun()
    {
        /*if (sao.transform.eulerAngles.z < 20f&& !(sao.transform.eulerAngles.x < 45f))
        {
            var angles = sao.transform.eulerAngles;
            angles.z += 21f;
            sao.transform.eulerAngles = angles;
        }*/
        //tama.AddForce(-transform.right*1000f);
        }
    void rightrun()
    {
        /*if (sao.transform.eulerAngles.z >- 20f && !(sao.transform.eulerAngles.x < 45f))
        {
            var angles = sao.transform.eulerAngles;
            angles.z -= 21f;
            sao.transform.eulerAngles = angles;
        }*/

        //tama.AddForce(transform.right * 1000f);

    }

    public void castoff()
    {
        bl = true;
    }
    public void off()
    {
        sao.SetActive(false);
    }
}
