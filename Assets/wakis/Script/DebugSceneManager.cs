using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wakis.fishObj;

public class DebugSceneManager : MonoBehaviour
{
    [SerializeField]
    getfishlist gf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            var anyone = Input.inputString;
            switch (anyone)
            {
                case "O":
                case "I":
                case "U":
                int num = int.Parse(anyone);
                    try
                    {
                        SceneManager.LoadScene(num);
                    }
                    catch
                    {
                        Debug.Log("Error");
                    }
                    break;
                case "r":
                case "R":gf.falser();
                    break;
            }
        }
    }
}
