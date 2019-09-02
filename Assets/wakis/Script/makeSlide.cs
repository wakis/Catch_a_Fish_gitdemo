using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using wakis.slidelist;
using UnityEngine.SceneManagement;

public class makeSlide : MonoBehaviour
{
    List<Sprite> slide = new List<Sprite>();
    List<SlideElement> LSE = new List<SlideElement>();
    public slidelist SL = new slidelist();
    int Slidenum = 0;
    SpriteRenderer sr;
    public string names;
    // Start is called before the first frame update
    void Start()
    {
        Slidenum = 0;
        Debug.Log("OK");
        LSE = SL.getSlideList;
        foreach (var sp in LSE)
        {
            slide.Add(sp.slideImage);
        }
        //slide = SL.getsp();
        sr =GetComponent<SpriteRenderer>();
        transform.position = Camera.main.transform.position+Vector3.forward*6.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Lotsignal.boolB)
        {
            Slidenum++;
        }else if((Input.GetKeyDown(KeyCode.N)&&Lotsignal.pointX[10] - Lotsignal.pointX[9] > 50f)&& Slidenum>0)
        {
            Slidenum--;
        }
        if (Slidenum<slide.Count)
        {
            sr.sprite = slide[Slidenum];
        }else
        {
            SceneManager.LoadScene(0);
        }
    }
}
