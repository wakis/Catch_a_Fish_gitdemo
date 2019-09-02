using System;
using System.IO;
using System.IO.Ports;
using UnityEngine;
using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SerialMain : MonoBehaviour
{
    static string signal;
    static public string signaler { get { return signal; } }
    [ContextMenuItem("Do to Trigger.name", "aa")]
    public string portName;
    public int baurate;
    SerialPort serial;
    static SerialPort endserial;
    [NonSerialized]
    public bool isLoop = true;

    void aa()
    {
        this.isLoop = false;
        try
        {
            endserial.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        Debug.Log("SerialClosed Unload");
    }
    void Start()
    {
        bool opencom = false;
        Debug.Log("start");
        this.serial = new SerialPort(portName, baurate, Parity.None, 8, StopBits.One);
        if(endserial==null) endserial = serial;
        try
        {
            this.serial.Open();
            Scheduler.ThreadPool.Schedule(() => ReadData()).AddTo(this);
        }
        catch (Exception e)
        {
            Debug.Log("can not open serial port");
            opencom = true;
        }
        if (opencom) Port_Start(1);
    }
    void Update()
    {
    }

    private void ReadData()
    {
        while (this.isLoop && this.serial != null && this.serial.IsOpen)
        {
            try
            {
                string str = this.serial.ReadLine();
                signal = str;
                Debug.Log(signal);
            }
            catch (System.Exception e)
            {
            }
        }
    }
    static byte[] buf;
    static public void Write(byte[] buffer)
    {
        if (buf == null) buf = buffer;
        if (buf[0] == buffer[0]) return;
        Debug.Log("try");
        try
        {
            endserial.Write(buffer, 0, 1);
            /*if (buffer[0]==1) {
                Debug.Log(buffer[0]);
                serial.Write(buffer, 0, 1);
            }else
            {
                serial.Write(buffer, 0, 1);
            }*/
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }
        buf = buffer;
    }

    private void OnApplicationQuit()
    {
        this.isLoop = false;
        try
        {
            endserial.Close();
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }

        Debug.Log("SerialClosed");
    }

    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
    public void Port_Start(int num)
    {
        bool opencom = false;
        Debug.Log("restart");
        portName = "COM" + num.ToString();
        this.serial = new SerialPort(portName, baurate, Parity.None, 8, StopBits.One);
        endserial = serial;

        try
        {
            this.serial.Open();
            Scheduler.ThreadPool.Schedule(() => ReadData()).AddTo(this);
        }
        catch (Exception e)
        {
            Debug.Log("can not open serial port");
            opencom = true;
        }
        if (num<10&&opencom)
        {
            Port_Start(num + 1);
        }
    }

}