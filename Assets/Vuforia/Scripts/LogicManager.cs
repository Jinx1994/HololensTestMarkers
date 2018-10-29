using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class LogicManager : MonoBehaviour {

    public static LogicManager instance;

    public GameObject ARWorld;
    public GameObject VRWorld;
    public GameObject[] UserInterfaces;

    private KeywordRecognizer keywordRecognizer;

    public string[] VoiceCommands;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        keywordRecognizer = new KeywordRecognizer(VoiceCommands);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (VoiceCommands.Length == 1)
        {
            if (args.text.ToLower().Equals(VoiceCommands[0].ToLower()))
            {   
                EnableARWorld();
            }
        }
    }

    public void EnableARWorld()
    {
        DisableUIs();
        ARWorld.SetActive(true);
        VRWorld.SetActive(false);
    }

    public void DisableARWorld()
    {   
        ARWorld.SetActive(false);
        VRWorld.SetActive(true);
    }

    public void LoadUIBasedOnMarker(string MarkerName)
    {
        DisableUIs();

        switch (MarkerName)
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
