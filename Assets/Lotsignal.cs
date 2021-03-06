﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Lotsignal : MonoBehaviour
{[SerializeField]
    SerialMain sm;
    static public int acceX;
    static public int acceY;
    static public int acceZ;

    static public int aveX;
    static public int aveY;
    static public int aveZ;

    static public int[] pointX = new int[11];
    static public int[] pointY = new int[11];
    static public int[] pointZ = new int[11];

    static public bool boolB;
    static public bool rostB;
    static public bool b;


    static public bool open;
    static public float opeave = -1f;
    static public int[] openum= { -1,-1};

    // Start is called before the first frame update
    void Start()
    {
        boolB = false;
        rostB = false;
    }
    void setOpen()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (openum[0] <= 0)
            {
                openum[0] = (int)opeave;
                if (openum[0] <= 0) openum[0] = -1;
            }
            else
            {
                openum[1] = (int)opeave;
                if(openum[1]< openum[0])
                {
                    openum[0] = openum[1] = -1;
                }
                if (openum[1] <= 0) openum[1] = -1;
            }
        }
        opeave = (openum[0] + openum[1]) / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        bool afb = b;
        setnum();
        setpoint();
        byte[] test=new byte[1];
        if (Input.GetKey(KeyCode.W))
        {
            byWrite(true);
            SerialMain.Write(test);
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            byWrite(false);
            SerialMain.Write(test);
        }
        if (b&&!afb)
        {
            boolB = true;
        }
        else 
        {
            boolB = false;
        }
        if (afb && !b)
        {
            rostB = true;
        }
        else
        {
            rostB = false;
        }
        //Debug.Log("onbool;"+boolB+"onrost;"+rostB);
    }
    void setnum()
    {
        var str = SerialMain.signaler;
        if (str == null) return;
        if(str[0] != 'X')
        {
            Debug.Log(str);
            return;
        }
        if (str[0] == 'X')
        {
            var strnum = str.Split('\t');
            foreach (var num in strnum)
            {
                switch (num[0])
                {
                    case 'X':
                        acceX= int.Parse(Regex.Replace(num, @"[^0-9]", ""));
                        break;
                    case 'Y':
                        acceY = int.Parse(Regex.Replace(num, @"[^0-9]", ""));
                        break;
                    case 'Z':
                        acceZ = int.Parse(Regex.Replace(num, @"[^0-9]", ""));
                        break;
                    case 'a':
                        if(int.Parse(Regex.Replace(num, @"[^0-9]", "")) > 0)
                        {
                            b = true;
                        }else
                        {
                            b = false;
                        }
                        break;
                    case 'r':
                        if (openum[0] > 0f && openum[1] > 0f)
                        {
                            if (int.Parse(Regex.Replace(num, @"[^0-9]", "")) > opeave)
                            {
                                open = true;
                            }
                            else
                            {
                                open = false;
                            }
                        }else
                        {
                            opeave = (float)int.Parse(Regex.Replace(num, @"[^0-9]", ""));
                            setOpen();
                        }
                        break;
                }
            }
        }
        else
        {
            return;
        }
    }
    void setpoint()
    {
        Vector3 act=new Vector3();
        for (int lp=1;lp<11;lp++)
        {
            pointX[lp - 1] = pointX[lp];
            pointY[lp - 1] = pointY[lp];
            pointZ[lp - 1] = pointZ[lp];
            act.x += pointX[lp - 1];
            act.y += pointY[lp - 1];
            act.z += pointZ[lp - 1];
        }
        aveX = (int)act.x / 10;
        aveY = (int)act.y / 10;
        aveZ = (int)act.z / 10;
        pointX[10] = acceX;
        pointY[10] = acceY;
        pointZ[10] = acceZ;
    }

    static public void byWrite(bool t_f)
    {
        byte[] test = new byte[1];
        if (t_f)
        {
            test[0] = (byte)'1';
            SerialMain.Write(test);
        }
        else
        {
            test[0] = (byte)'0';
            SerialMain.Write(test);
        }
    }
}
