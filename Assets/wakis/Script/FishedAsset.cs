using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class FishedAsset
{
    public static GameObject x;
    public static List<GameObject> FishedList = new List<GameObject>();
    static FishedAsset()
    {
        x = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

}
