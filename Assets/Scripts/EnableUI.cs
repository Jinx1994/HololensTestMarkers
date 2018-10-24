using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableUI : MonoBehaviour {

    public GameObject[] UIs;

    void Start()
    {
        switch (LoadScene.UIIndex)
        {
            case 10:
                UIs[0].SetActive(true);
                break;
            case 1:
                UIs[1].SetActive(true);
                break;
            case 2:
                UIs[2].SetActive(true);
                break;
            case 9:
                UIs[3].SetActive(true);
                break;
            case 8:
                UIs[4].SetActive(true);
                break;
            case 7:
                UIs[5].SetActive(true);
                break;
            case 6:
                UIs[6].SetActive(true);
                break;
            case 5:
                UIs[7].SetActive(true);
                break;
            default:
                break;
        }
    }
}
