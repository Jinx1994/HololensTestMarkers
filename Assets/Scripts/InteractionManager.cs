using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.Windows.Speech;


public class InteractionManager : MonoBehaviour, IVirtualButtonEventHandler {

    private int index;
    private int points;

    private KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public TextMeshProUGUI MessageText;
    public TextMeshProUGUI PointsText;

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
        SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        RepairButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        index = 0;
        points = 0;
        keywordRecognizer = new KeywordRecognizer(VoiceCommands);
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {  
        switch(args.text.ToLower())
        {
            case "switch":
                SwitchMessageText();
                break;
            case "one":
                SwitchToReward();
                break;
            default:
                break;
        }       
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        string temp = SwitchMessageButton.name.ToLower();
        string temp2 = RepairButton.name.ToLower();
        
        if(vb.gameObject.name.ToLower().Equals(temp))
        {
            SwitchMessageText();
        }
        else if(vb.gameObject.name.ToLower().Equals(temp2))
        {
            SwitchToReward();
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
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

    private void SwitchMessageText()
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

    private void SwitchToReward()
    {
        StatusIcon.sprite = IconProvider.instance.RewardIcon;
        RepairButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
        SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().enabled = false;
        SwitchMessageButton.SetActive(false);
        RepairButton.SetActive(false);
        MessageText.text = RewardText;
        points += 20;
        PointsText.text = "Points: " + points;
    }
}
