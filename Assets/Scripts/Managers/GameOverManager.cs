using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
	[Header("Parameters")]
	[SerializeField] private string playerScorePrefix = "Your Score: ";
	[SerializeField] private string highScorePrefix = "High Score: ";

	[Header("References")]
	[SerializeField] private TextMeshProUGUI playerFinalScoreText;
	[SerializeField] private TextMeshProUGUI highScoreText;

	private void OnEnable()
	{
		int playerFinalScore = GUIManager.Instance.Score;
		playerFinalScoreText.text = playerScorePrefix + playerFinalScore;

		if (playerFinalScore > GameData.HighScore)
		{
			GameData.HighScore = playerFinalScore;
		}
		highScoreText.text = highScorePrefix + GameData.HighScore;
	}
}
