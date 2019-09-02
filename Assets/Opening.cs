using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Opening : MonoBehaviour
{
    enum set
    {
        non=-1,
        start,
        st,
        n19,
        n50,
        mv,
    }
    [SerializeField]
    TextMesh year;
    [SerializeField]
    SpriteRenderer fade;
    [SerializeField]
    SpriteRenderer fish;
    [SerializeField]
    VideoPlayer vp;
    [SerializeField]
    SpriteRenderer vppx;
    [SerializeField]
    AudioSource bgm;
    [SerializeField]
    AudioSource wave;
    [SerializeField]
    float[] ptime=new float[4];
    set zone;
    float timer;
    int years;
    Vector3 fishpoint;
    // Start is called before the first frame update
    void Start()
    {
        wave.volume = 1f;
        bgm.volume = 0f;
        if (fishpoint==Vector3.zero) fishpoint = fish.transform.position;
        timer = 0;
        fade.color = new Color(1f, 1f, 1f, 0f);
        year.color = new Color(1f, 1f, 1f, 0f);
        fish.transform.position = fishpoint;
        fade.transform.position = new Vector3(0f, 1f, -6f);
        //vp.enabled = false;
        vp.Stop();
        vp.Prepare();
        vppx.enabled = false;
        vppx.color = new Color(1f, 1f, 1f, 1f);
        zone = set.start;
        years = 2019;
        year.text = years.ToString();
    }

    void n2019()
    {
        fade.color = year.color = new Color(1f, 1f, 1f, 1f);
        wave.volume = 0f;
        timer = ptime[1]+ptime[0];
        zone = set.n19;
    }
    void n2050()
    {
        timer = ptime[2]+ptime[1]+ ptime[0];
        zone = set.n50;
    }
    void mvst()
    {
        bgm.volume = 1f;
        vp.targetCameraAlpha = 1f;
        //vp.enabled = true;
        vp.Play();
        timer = ptime[3]+ ptime[2] + ptime[1] + ptime[0];
        if(vp.enabled) zone = set.mv;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (zone)
        {
            case set.start:
                if (timer > ptime[0]) zone++;
                break;
            case set.st:
                var c = fade.color = year.color;
                c.a+=Time.deltaTime/ ptime[0];
                fade.color = year.color = c;
                wave.volume = 1f - c.a;
                if (timer > ptime[0]+ ptime[1]) n2019();
                break;
            case set.n19:
                if ((timer < ptime[1] * 0.2 + ptime[0]))years = 2019;
                else if (years < 2050) years+=1;
                year.text = years.ToString();
                if (timer > ptime[2]+ptime[1]+ ptime[0]) n2050();
                break;
            case set.n50:
                if (fish.transform.position.x > -1f* fishpoint.x)
                {
                    var fishs = fish.transform.position;
                    var tops = fade.transform.position;
                    fishs.x -= Time.deltaTime * 2f* fishpoint.x / ptime[2];
                    tops.x -= Time.deltaTime * 14f / ptime[2];
                    bgm.volume += Time.deltaTime/ptime[2];
                    fish.transform.position = fishs;
                    fade.transform.position= tops;
                }
                if(1f> fish.transform.position.x && fish.transform.position.x > -1f && year.color.a > 0f)
                {
                    year.color = new Color(1f, 1f, 1f, 0f);
                    vppx.enabled = true;
                }
                if (timer > ptime[3]+ptime[2] + ptime[1] + ptime[0]) mvst();
                break;
            case set.mv:
                if (!vp.isPlaying && vp.enabled)
                {
                    var cv = vp.targetCameraAlpha;
                    cv -= Time.deltaTime/3f;
                    vp.targetCameraAlpha = cv;
                    wave.volume = 1f-cv;
                    bgm.volume = cv;
                    vppx.color =new Color(1f,1f,1f,0f);
                    if (!(cv > 0f))
                    {
                        Start();
                    }
                }
                break;
        }
    }
}
