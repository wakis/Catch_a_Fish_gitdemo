using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;
namespace wakis.slidelist
{
    [Serializable]
    public class SlideElement
    {
        public Sprite slideImage;
    }
    public enum Trigger
    {
        non = -1,
        Slide_In_List,
        Create_Slide,
    }
    [CreateAssetMenu(menuName = "Obj/SlideList", fileName = "New SlideList")]
    public class slidelist : ScriptableObject
    {
        [ContextMenuItem("Do to Trigger.name", "DoToTrigger")]
        public Trigger trigger = Trigger.non;
        [SerializeField]
        internal List<SlideElement> SlideList = new List<SlideElement>();
        //internal List<SlideElement> setSlideList = new List<SlideElement>();
        public List<SlideElement> getSlideList { get { return SlideList; } }
        static public List<Sprite> spr = new List<Sprite>();
        public List<Sprite> getsp()
        {
            foreach (var sp in SlideList)
            {
                spr.Add(sp.slideImage);
            }
            return spr;
        }
        void DoToTrigger()
        {
            switch (trigger)
            {
                case Trigger.non:
                    break;
                case Trigger.Slide_In_List:
                    Slide_In_List();
                    break;
                case Trigger.Create_Slide:
                    Create_Slide();
                    break;
                default:
                    break;
            }

            trigger = Trigger.non;
        }

        void Slide_In_List()
        {
            var anyone = Resources.LoadAll("SlideList", typeof(Sprite));
            SlideList.Clear();
            foreach (Sprite other in anyone)
            {
                SlideElement SE = new SlideElement();
                SE.slideImage = other;
                SlideList.Add(SE);
            }
        }

        void Create_Slide()
        {
            Debug.Log("0k");
            var sl = new GameObject();
            //var at =Instantiate(sl);
            sl.AddComponent<SpriteRenderer>();
            var x = sl.AddComponent<makeSlide>();
            x.SL = this;
        }

        void OnValidate()
        {
            /*foreach (var Slide in SlideList)
            {
                if (Slide.slideImage != null && Slide.slideVideo != null)
                {
                    Slide.slideVideo = null;
                }
            }*/
        }
    }
}
