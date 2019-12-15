using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
	public static GUIManager Instance { get; private set; }

	[SerializeField] private TextMeshProUGUI scoreTextFiled;
	[SerializeField] private GameObject windIndicatorRef;
	[SerializeField] private string defaultScorePrefix = "Score: ";
	[SerializeField] private Color highScoreColor = Color.yellow;

	[SerializeField] private AudioExpress hitSound;

	protected void Awake() => Instance = this;

	public int Score { get; private set; }

	private void Start() => scoreTextFiled.text = defaultScorePrefix + Score;

	internal void UpdateScore(int s = 0)
	{
		Score += s;
		scoreTextFiled.text = defaultScorePrefix + Score;

		if (Score > GameData.HighScore)
		{
			scoreTextFiled.color = highScoreColor;
		}

		hitSound.Play(gameObject);
	}

	internal void updateWindGUI(Vector3 wind_vel)
	{
		//Debug.Log(wind_vel);
		if (wind_vel == Vector3.zero) // Wind is disabled
		{
			windIndicatorRef.SetActive(false);
		}

		// Enabled wind, alter GUI arrow to match wind velocity
		float angle = Mathf.Atan2(wind_vel.z, wind_vel.x) * Mathf.Rad2Deg;
		//Debug.Log("Angle: " + angle);
		//Debug.Log("Mag: " + wind_vel.magnitude);
		windIndicatorRef.GetComponent<RectTransform>().localScale = new Vector3(wind_vel.magnitude, wind_vel.magnitude, 1);
		windIndicatorRef.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, angle);
	}
}
