using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindBehavior : MonoBehaviour
{
	public static WindBehavior Instance { get; private set; }

	[SerializeField] private bool enable_wind = false;
	[SerializeField] private float minMagnitude = 0f;
	[SerializeField] private float maxMagnitude = 5f;
	[SerializeField] private float minChangeTimeSeconds = 10f;
	[SerializeField] private float maxChangeTimeSeconds = 30f;
    [SerializeField] private float windZoneEffectScale = 0.005f;

    private Vector3 wind_vel;
	private float lastChangeTime;
	private float randomChangeWait;

	private void Awake()
	{
		Instance = this;

		Game.Instance.OnStartGame += NewWind;
	}

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

        // Update object rotation to change Wind Zone component for particle drift
        this.transform.LookAt(wind_vel);
        this.GetComponent<WindZone>().windMain = new_mag * windZoneEffectScale;

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

	private void Update()
	{
		if ((Time.time - lastChangeTime) > randomChangeWait)
		{
			NewWind();
		}
	}

	private void OnDestroy()
	{
		Game.Instance.OnStartGame -= NewWind;
	}
}
