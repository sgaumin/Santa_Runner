using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehavior : MonoBehaviour
{
	[SerializeField] private int points_increment = 1;
	[SerializeField] private int wind_scale = 50;
	[SerializeField] private string scoreColliderTag = "Chimney";
	[SerializeField] private GameObject refGM;
	[SerializeField] private GameObject refWind;

	private Rigidbody body;

	public void SetGMRef(GameObject rGM)
	{
		refGM = rGM;
	}

	public void SetWindRef(GameObject rWind)
	{
		refWind = rWind;
	}

	private void Awake()
	{
		body = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		// Apply wind, can disable on Wind object inspector
		Vector3 wind_vel = refWind.GetComponent<WindBehavior>().GetWindVel();
		body.AddForce(wind_vel * Time.deltaTime * wind_scale);
	}

	// Delete self when invisible to clear up memory resources
	private void OnBecameInvisible()
	{
		//Debug.Log("Destroying present");
		Destroy(this.gameObject);
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == scoreColliderTag && refGM != null)
		{
			GUIManager.Instance?.UpdateScore(points_increment);
			Destroy(this.gameObject);
		}
	}
}
