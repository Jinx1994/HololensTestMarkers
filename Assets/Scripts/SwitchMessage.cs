using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using TMPro;

public class SwitchMessage : MonoBehaviour, IVirtualButtonEventHandler {

    private int index;

    public TextMeshProUGUI MessageText;

    public Sprite ToSolutionIcon;
    public Sprite ToProblemIcon;
    public Sprite AttentionIcon;
    public Sprite SolutionIcon;

    public UnityEngine.UI.Image SwitchMessageIcon;
    public UnityEngine.UI.Image StatusIcon;

    public string Problem;
    public string Solution;

    public GameObject SwitchMessageButton;

    // Use this for initialization
    void Start()
    {
        SwitchMessageButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        index = 0;
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if(index == 0)
        {
            SwitchToSolution();
        }
        else
        {
            SwitchToProblem();
        }
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
}
