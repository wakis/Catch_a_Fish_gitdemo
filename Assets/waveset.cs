using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveset : MonoBehaviour
{
    AudioSource audiose;
    AudioClip sewave;
    float timer;
    float on;
    // Start is called before the first frame update
    void Start()
    {
        audiose = GetComponent<AudioSource>();
        sewave = audiose.clip;
        timer = 0f;
        on = Random.Range(3f,6f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>on)
        {
            audiose.Play();//PlayOneShot(sewave);
            if ((int)(Random.Range(0, 10) % 2) == 0) on = 0f;
            else on = Random.Range(4f,7f);
            timer = 0;
        }
    }
}
