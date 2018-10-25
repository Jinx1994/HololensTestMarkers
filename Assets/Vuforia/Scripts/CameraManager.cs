using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject ARWorld;
    public UIManager uiManager;

    public void EnableARWorld()
    {
        uiManager.DisableUIs();
        ARWorld.SetActive(true);
    }

    public void DisableARWorld()
    {   
        ARWorld.SetActive(false);
    }
}
