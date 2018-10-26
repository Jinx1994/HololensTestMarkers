using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class CameraManager : MonoBehaviour {

    public GameObject ARWorld;
    public GameObject VRWorld;

    public UIManager uiManager;

    private KeywordRecognizer keywordRecognizer;

    public string[] VoiceCommands;

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
        uiManager.DisableUIs();
        ARWorld.SetActive(true);
        VRWorld.SetActive(false);
    }

    public void DisableARWorld()
    {   
        ARWorld.SetActive(false);
        VRWorld.SetActive(true);
    }
}
