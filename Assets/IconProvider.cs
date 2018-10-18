using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconProvider : MonoBehaviour {

    public static IconProvider instance;

    public Sprite ToSolutionIcon;
    public Sprite ToProblemIcon;
    public Sprite AttentionIcon;
    public Sprite SolutionIcon;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
