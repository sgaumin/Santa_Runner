using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkCreationTrigger : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("EndChunk"))
		{
			BuildingChunkGenerator.Instance.SpawnChunk();
		}
	}
}
