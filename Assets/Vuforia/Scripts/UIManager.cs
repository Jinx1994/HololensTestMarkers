using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject[] UserInterfaces;

    public void LoadUIBasedOnMarker(string MarkerName)
    {
        DisableUIs();

        switch(MarkerName)
        {
            case "Target1":
                UserInterfaces[1].SetActive(true);
                break;
            case "Target2":
                UserInterfaces[2].SetActive(true);
                break;
            case "Target5":
                UserInterfaces[7].SetActive(true);
                break;
            case "Target6":
                UserInterfaces[6].SetActive(true);
                break;
            case "Target7":
                UserInterfaces[5].SetActive(true);
                break;
            case "Target8":
                UserInterfaces[4].SetActive(true);
                break;
            case "Target9":
                UserInterfaces[3].SetActive(true);
                break;
            case "Target10":
                UserInterfaces[0].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void DisableUIs()
    {
        foreach (GameObject UI in UserInterfaces)
        {
            UI.SetActive(false);
        }
    }
}
