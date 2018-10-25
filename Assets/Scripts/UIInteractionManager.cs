using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows.Speech;


public class UIInteractionManager : MonoBehaviour {

    private int index;
    public int pointsForReward;

    private KeywordRecognizer keywordRecognizer;

    public TextMeshProUGUI MessageText;

    public UnityEngine.UI.Image SwitchMessageIcon;
    public UnityEngine.UI.Image StatusIcon;

    public string ProblemText;
    public string SolutionText;
    public string RewardText;
    public string[] VoiceCommands;

    public GameObject SwitchMessageButton;
    public GameObject RepairButton;

    // Use this for initialization
    void Start()
    {
        //SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //RepairButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        index = 0;
        keywordRecognizer = new KeywordRecognizer(VoiceCommands);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {  
        if(VoiceCommands.Length >= 2)
        {
            if(args.text.ToLower().Equals(VoiceCommands[0].ToLower()))
            {
                SwitchMessageText();
            }
            else if(args.text.ToLower().Equals(VoiceCommands[1].ToLower()))
            {
                SwitchToReward();
            }
        }    
    }

    private void SwitchToSolution()
    {
        StatusIcon.sprite = IconProvider.instance.SolutionIcon;
        SwitchMessageIcon.sprite = IconProvider.instance.ToProblemIcon;
        MessageText.text = SolutionText;
        index = 1;       
    }

    private void SwitchToProblem()
    {
        StatusIcon.sprite = IconProvider.instance.AttentionIcon;
        SwitchMessageIcon.sprite = IconProvider.instance.ToSolutionIcon;
        MessageText.text = ProblemText;
        index = 0;
    }

    public void SwitchMessageText()
    {
        if (index == 0)
        {
            SwitchToSolution();
        }
        else
        {
            SwitchToProblem();
        }
    }

    public void SwitchToReward()
    {
        StatusIcon.sprite = IconProvider.instance.RewardIcon;
        //RepairButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
        //SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
        SwitchMessageButton.SetActive(false);
        RepairButton.SetActive(false);
        MessageText.text = RewardText;
        IconProvider.instance.points += pointsForReward;
        keywordRecognizer.Stop();
    }
}
