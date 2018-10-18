using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Windows.Speech;


public class SwitchMessage : MonoBehaviour, IVirtualButtonEventHandler {

    private int index;

    private KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public TextMeshProUGUI MessageText;

    public Sprite ToSolutionIcon;
    public Sprite ToProblemIcon;
    public Sprite AttentionIcon;
    public Sprite SolutionIcon;

    public UnityEngine.UI.Image SwitchMessageIcon;
    public UnityEngine.UI.Image StatusIcon;

    public string Problem;
    public string Solution;
    public string SwitchCommand;

    public GameObject SwitchMessageButton;

    // Use this for initialization
    void Start()
    {
        SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        keywords.Add(SwitchCommand, () =>
        {
            Switch();
        });
        index = 0;
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if(keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Switch();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
    }

    private void SwitchToSolution()
    {
        StatusIcon.sprite = SolutionIcon;
        SwitchMessageIcon.sprite = ToProblemIcon;
        MessageText.text = Solution;
        index = 1;       
    }

    private void SwitchToProblem()
    {
        StatusIcon.sprite = AttentionIcon;
        SwitchMessageIcon.sprite = ToSolutionIcon;
        MessageText.text = Problem;
        index = 0;
    }

    private void Switch()
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
}
