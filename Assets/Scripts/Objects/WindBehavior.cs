using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : MonoBehaviour
{
	[SerializeField] private bool enable_wind = false;
	[SerializeField] private float minMagnitude = 0f;
	[SerializeField] private float maxMagnitude = 5f;
	[SerializeField] private float minChangeTimeSeconds = 10f;
	[SerializeField] private float maxChangeTimeSeconds = 30f;

	[SerializeField] private GameObject refGM;

	private Vector3 wind_vel;
	private float lastChangeTime;
	private float randomChangeWait;

	public Vector3 GetWindVel()
	{
		if (enable_wind)
			return wind_vel;

		return Vector3.zero; // no wind
	}

	private void NewWind()
	{
		randomChangeWait = Random.Range(minChangeTimeSeconds, maxChangeTimeSeconds);
		lastChangeTime = Time.time;
		// Change the wind direction and speed
		float new_mag = Random.Range(minMagnitude, maxMagnitude);
		Vector2 unit_dir = Random.insideUnitCircle * new_mag;
		wind_vel = new Vector3(unit_dir.x, 0, unit_dir.y);

		// Update GUI
		if (enable_wind)
		{
			GUIManager.Instance?.updateWindGUI(wind_vel);
		}
		else
		{
			GUIManager.Instance?.updateWindGUI(Vector3.zero);
		}
	}

	private void Start()
	{
		NewWind();
	}

	private void Update()
	{
		if ((Time.time - lastChangeTime) > randomChangeWait)
		{
			NewWind();
		}
	}
}
