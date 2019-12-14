using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	[SerializeField] private float presentSpeed = 60;
	[SerializeField] private float shootCDSeconds = 0.5f;

	[SerializeField] private GameObject presentPrefab;
	[SerializeField] private GameObject hitPlane;

	[Header("ScreenShake Parameters")]
	[SerializeField, Range(0f, 1f)] private float amplitude = 0.1f;
	[SerializeField, Range(0f, 1f)] private float duration = 0.2f;

	private float last_shot_time;

	int layer_mask;

	void Start()
	{
		layer_mask = LayerMask.GetMask("HitPlane");
		last_shot_time = Time.time;
	}
	void Update()
	{
		if (Game.Instance.GameState == Game.GameStates.Play)
		{
			if (Input.GetButtonDown("Fire1") && (Time.time - last_shot_time) > shootCDSeconds)
			{
				Plane plane = new Plane(Vector3.up, Vector3.zero);
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit[] hits = Physics.RaycastAll(ray.origin, ray.direction, Mathf.Infinity, layer_mask).OrderBy(h => h.distance).ToArray();
				//Debug.Log("hits:" + hits.Length);
				// Debug.Log("hits:" + hits.Length);
				for (int i = 0; i < hits.Length; i++)
				{
					RaycastHit hit = hits[i];
					if (hit.collider.gameObject == hitPlane)
					{
						Vector3 finalClickPos = hit.point;
						// Debug.Log("finalClickPos " + finalClickPos);
						GameObject present = Instantiate(presentPrefab, transform.position, Quaternion.LookRotation(finalClickPos));
						present.GetComponent<Rigidbody>().AddForce((finalClickPos - present.transform.position) * presentSpeed);
						last_shot_time = Time.time;
					}
				}

				ScreenShake.Instance.Shake(amplitude, duration);
			}
		}
	}
}
