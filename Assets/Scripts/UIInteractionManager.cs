using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows.Speech;


public class UIInteractionManager : MonoBehaviour {

    private int problemIndex;

    private KeywordRecognizer keywordRecognizer;

    public TextMeshProUGUI SolutionMessage;

    public string[] SolutionTexts;
    public string[] VoiceCommands;
    private string SolutionText;

    public GameObject SolutionPanel;
    public GameObject ProblemPanel;
    public GameObject[] ProblemMessages;
    public GameObject ComponentImage;
    public GameObject WarningImage;

    // Use this for initialization
    void Start()
    {
        keywordRecognizer = new KeywordRecognizer(VoiceCommands);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {  
        if(VoiceCommands.Length == 3)
        {
            if(args.text.ToLower().Equals(VoiceCommands[0].ToLower()) && ProblemMessages[0].activeSelf)
            {
                SetSolutionText(0);
                SwitchToSolutionPanel(true);
            }
            else if(args.text.ToLower().Equals(VoiceCommands[1].ToLower()) && ProblemMessages[0].activeSelf)
            {
                problemIndex = 0;
                ResolveProblem();
            }
            else if (args.text.ToLower().Equals(VoiceCommands[2].ToLower()))
            {
                SwitchToProblemPanel();
            }
        }    
    }

    public void SwitchToSolutionPanel(bool showSolutionImage = false)
    {   
        if(showSolutionImage)
        {
            ComponentImage.SetActive(true);
        }
        else
        {
            ComponentImage.SetActive(false);
        }
        ProblemPanel.SetActive(false);
        SolutionPanel.SetActive(true);
        SolutionMessage.text = SolutionText;     
    }

    public void SwitchToProblemPanel()
    {
        ProblemPanel.SetActive(true);
        SolutionPanel.SetActive(false);
    }

    public void ResolveProblem()
    {
        SwitchToProblemPanel();
        ProblemMessages[problemIndex].SetActive(false);
        DisableWarningIcon();
    }

    public void SetSolutionText(int index)
    {
        SolutionText = SolutionTexts[index];
        problemIndex = index;       
    }

    private void DisableWarningIcon()
    {
        bool noProblemMessagesLeft = true;

        foreach(GameObject ProblemMessage in ProblemMessages)
        {
            if(ProblemMessage.activeSelf)
            {
                noProblemMessagesLeft = false;
                break;
            }
        }

        if(noProblemMessagesLeft)
        {
            WarningImage.SetActive(false);
            //LogicManager.instance.EnableARWorld();
        }
    }
}
