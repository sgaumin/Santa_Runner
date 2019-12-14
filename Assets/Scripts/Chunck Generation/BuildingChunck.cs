using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChunck : MonoBehaviour
{
	private void Update()
	{
		Vector3 currentPosition = transform.position;
		Vector3 nextPosition = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - BuildingChunckGenerator.Instance.ChunckMovementSpeed);
		transform.position = nextPosition;
	}
}
