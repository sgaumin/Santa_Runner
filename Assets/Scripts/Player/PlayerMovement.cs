using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float movementSpeed = 100f;

	private Vector3 movement;
	private Rigidbody body;

	protected void Start()
	{
		body = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		movement.x = Input.GetAxis("Horizontal");
		movement.z = Input.GetAxis("Vertical");

		body.AddForce(movement * movementSpeed * Time.deltaTime);
	}
}
