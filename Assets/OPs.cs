using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class OPs : MonoBehaviour
{
    public string names;
    int stage;
    bool oneside;
    [SerializeField]
    VideoPlayer vp;
    [SerializeField]
    SpriteRenderer sr;
    bool nonset = false;
    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        oneside = false;
        vp.enabled = false;
        nonset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Lotsignal.boolB)
        {
            if (!nonset) nonset = true;
            stage++;
        }else if (stage>10)
        {
            SceneManager.LoadScene(names);
        }
        if (vp.isPlaying) oneside = true;
        if (stage>0&&!vp.isPlaying&& oneside)
        {
            SceneManager.LoadScene(names);
        }
        if (nonset)
        {
            if (sr.color.a>0.01f) {
                var c = sr.color;
                c.a -= 0.5f * Time.deltaTime;
                sr.color = c;
            }else
            {
                if (!vp.enabled) vp.enabled = true;
            }
        }
    }
    
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        Debug.Log("load");
    }
}
