using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPoints : MonoBehaviour {

    public TextMeshProUGUI PointsText;

    void Update()
    {
        PointsText.text = "Points: " + IconProvider.instance.points;
    }
}
