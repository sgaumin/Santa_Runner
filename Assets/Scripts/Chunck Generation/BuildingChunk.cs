using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingChunk : MonoBehaviour
{
	private void Update()
	{
		Vector3 currentPosition = transform.position;
		Vector3 nextPosition =
			new Vector3(currentPosition.x, currentPosition.y, currentPosition.z - BuildingChunkGenerator.Instance.ChunckMovementSpeed);
		transform.position = nextPosition;
	}
}
