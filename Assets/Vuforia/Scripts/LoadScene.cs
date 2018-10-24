using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public static int UIIndex;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void ChangeUIIndexAndLoadScene(string MarkerName)
    {
        switch(MarkerName)
        {
            case "Target1":
                UIIndex = 1;
                break;
            case "Target2":
                UIIndex = 2;
                break;
            case "Target5":
                UIIndex = 5;
                break;
            case "Target6":
                UIIndex = 6;
                break;
            case "Target7":
                UIIndex = 7;
                break;
            case "Target8":
                UIIndex = 8;
                break;
            case "Target9":
                UIIndex = 9;
                break;
            case "Target10":
                UIIndex = 10;
                break;
            default:
                break;
        }
        SceneManager.LoadScene(1);
    }
}
