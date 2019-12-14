using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private GameObject scoreTextFiled;
    [SerializeField] private String defaultScorePrefix = "Score: ";

    internal void updateScore(int score)
    {
        scoreTextFiled.GetComponent<TextMeshProUGUI>().text = defaultScorePrefix + score;
    }
}
