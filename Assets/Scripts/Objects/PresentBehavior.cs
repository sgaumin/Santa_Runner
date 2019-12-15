using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehavior : MonoBehaviour
{
	[SerializeField] private int points_increment = 1;
	[SerializeField] private int wind_scale = 50;
	[SerializeField] private string scoreColliderTag = "Chimney";

	[Space]
	[SerializeField] private float timeBeforeDestruction = 5f;

	[Header("References")]
	[SerializeField] private ParticleSystem hitEffect;
	[SerializeField] private GameObject[] models;

	private Rigidbody body;

	private void Awake() => body = GetComponent<Rigidbody>();

	private void Start()
	{
		models.Random().gameObject.SetActive(true);
		StartCoroutine(LaunchDestroyAnimation());
	}

	private void Update()
	{
		// Apply wind, can disable on Wind object inspector
		Vector3 wind_vel = WindBehavior.Instance.GetWindVel();
		body.AddForce(wind_vel * Time.deltaTime * wind_scale);
	}

	private void OnCollisionEnter(Collision collision)
	{
		//Debug.Log(collision.gameObject.tag);
		if (collision.gameObject.tag == scoreColliderTag)
		{
			if (collision.gameObject.GetComponent<ChimneyBehavior>().AddPresent(1))
			{
				GUIManager.Instance?.UpdateScore(points_increment);
				Instantiate(hitEffect, transform.position, Quaternion.identity, collision.transform);
				Destroy(this.gameObject);
			}
		}
	}

	private IEnumerator LaunchDestroyAnimation()
	{
		yield return new WaitForSeconds(timeBeforeDestruction);
		transform.DOScale(0f, 1f).SetEase(Ease.InBounce).Play();
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
