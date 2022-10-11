using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int Point = 0;

    public TextMeshProUGUI PointText;

    public void Awake()
    {
        instance = this;
    }


    public void IncreasePoint(int value)
    {
        Point +=value;
        PointText.text = $"{Point}";
    }
}
