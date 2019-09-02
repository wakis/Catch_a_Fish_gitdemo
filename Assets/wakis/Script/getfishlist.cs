using System;
using System.Collections.Generic;
using UnityEngine;
namespace wakis.fishObj{
    [Serializable]
    public class FishElement
    {
        public GameObject fish;
        public float percent = 1f;
        public bool hitter;
    }
    public enum Trigger
    {
        non=-1,
        Fishprefab_In_List,
        Set_All_False,
        Debug_SetRand_True,
    }

    [CreateAssetMenu(menuName = "Obj/FishObj", fileName = "New FishObjList")]
    public class getfishlist : ScriptableObject
    {
        [ContextMenuItem("Do to Trigger.name", "DoToTrigger")]
        public Trigger trigger = Trigger.non;
        [SerializeField]
        internal List<FishElement> fishList = new List<FishElement>();
        public List<FishElement> getFishList { get { return fishList; }}
        
        public float listps()
        {
            float num = 0;
            foreach (var fl in fishList) num += fl.percent;
            return num;
        }
        public GameObject hitobj(float No)
        {
            No = No % listps();
            float num = 0;
            int n = 0;
            while (true)
            {
                num += fishList[n].percent;
                if (num > No) break;
                n++;
            }
            if (!fishList[n].hitter)//初ヒット処理
            {
                fishList[n].hitter = true;
                Debug.Log("new hit");
            }
            return fishList[n].fish;
        }

        //トリガー類関数
        void DoToTrigger()
        {
            switch (trigger)
            {
                case Trigger.non:
                    break;
                case Trigger.Fishprefab_In_List:
                    fishprefabInList();
                    break;
                case Trigger.Set_All_False:
                    allFalse();
                    break;
                case Trigger.Debug_SetRand_True:
                    SetRandTrue();
                    break;
                default:
                    break;
            }
            
            trigger = Trigger.non;
        }

        void fishprefabInList()
        {
            var anyone = Resources.LoadAll("Fishprefab", typeof(GameObject));
            fishList.Clear();
            foreach (GameObject other in anyone)
            {
                FishElement FE = new FishElement();
                FE.fish = other;
                FE.percent = 1f;
                fishList.Add(FE);
            }
        }
        void allFalse()
        {
            int num = 0;
            foreach (var fl in fishList)
            {
                fishList[num].hitter = false;
                num++;
            }
        }
        void SetRandTrue()
        {
            int num = 0;
            foreach (var fl in fishList)
            {
                if (UnityEngine.Random.Range(0,2)==1) fishList[num].hitter = true;
                num++;
            }
        }
        //トリガー類関数END
        public void falser()
        {
            allFalse();
        }
    }
    
}
