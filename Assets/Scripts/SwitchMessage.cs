using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vuforia;
using TMPro;
using UnityEngine.Windows.Speech;


public class SwitchMessage : MonoBehaviour, IVirtualButtonEventHandler {

    private int index;

    private KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    public TextMeshProUGUI MessageText;

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
        StatusIcon.sprite = IconProvider.instance.SolutionIcon;
        SwitchMessageIcon.sprite = IconProvider.instance.ToProblemIcon;
        MessageText.text = Solution;
        index = 1;       
    }

    private void SwitchToProblem()
    {
        StatusIcon.sprite = IconProvider.instance.AttentionIcon;
        SwitchMessageIcon.sprite = IconProvider.instance.ToSolutionIcon;
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
