using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTextFiled;
    [SerializeField] private String defaultScorePrefix = "Score: ";

    private int score = 0;

    internal void updateScore(int s)
    {
        score += s;
        scoreTextFiled.GetComponent<TextMeshProUGUI>().text = defaultScorePrefix + score;
    }
}
